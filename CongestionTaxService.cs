using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using congestion.calculator.Entity;
using congestion.calculator;
using Microsoft.EntityFrameworkCore;

public class CongestionTaxService
{
    private readonly ApplicationDbContext _context;

    public CongestionTaxService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<decimal> CalculateTaxAsync(string cityName, string vehicleType, DateTime[] dates)
    {
        if (await IsTaxExemptAsync(vehicleType))
        {
            return 0;
        }

        var city = await _context.Cities
            .Include(c => c.CongestionConfigs)
            .Include(c => c.CongestionTaxes)
            .Include(c => c.OffDays)
            .Include(c => c.OffDates)
            .FirstOrDefaultAsync(c => c.Name == cityName);

        if (city == null)
        {
            throw new Exception("City not found");
        }

        var config = city.CongestionConfigs.FirstOrDefault();
        if (config == null)
        {
            throw new Exception("City configuration not found");
        }

        var maxAmountPerDay = config.MaxAmountPerDay;
        var singleChargeRuleMinutes = config.SingleChargeRuleMinute;

        decimal totalTax = 0;

        var groupedDates = dates
            .Where(d => d.Year == 2013)
            .GroupBy(d => d.Date)
            .OrderBy(g => g.Key);

        foreach (var dateGroup in groupedDates)
        {
            if (await IsTaxFreeDate(city, dateGroup.Key))
            {
                continue;
            }

            decimal dailyTax = 0;
            DateTime lastTollTime = dateGroup.First();

            foreach (var date in dateGroup.OrderBy(d => d))
            {
                if ((date - lastTollTime).TotalMinutes <= singleChargeRuleMinutes)
                {
                    dailyTax -= GetTaxAmount(city, lastTollTime);
                }

                var taxAmount = GetTaxAmount(city, date);
                dailyTax += taxAmount;

                if (dailyTax > maxAmountPerDay)
                {
                    dailyTax = maxAmountPerDay;
                }

                lastTollTime = date;
            }

            totalTax += dailyTax;
        }

        return totalTax;
    }


    private async Task<bool> IsTaxExemptAsync(string vehicleType)
    {
        var exemptVehicleTypes = await _context.VehicleTaxInfos
            .Where(vti => vti.IsTaxFree)
            .Select(vti => vti.VehicleType.Name)
            .ToListAsync();

        return exemptVehicleTypes.Contains(vehicleType);
    }


   
    private async Task<bool> IsTaxFreeDate(City city, DateTime date)
    {
        var isWeekend = date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday;
        var isPublicHoliday = await _context.OffDates
            .AnyAsync(od => od.CityId == city.Id && od.Year == date.Year && od.Month == date.Month && od.Day == date.Day);
        var isDayBeforePublicHoliday = await _context.OffDates
            .AnyAsync(od => od.CityId == city.Id && od.Year == date.Year && od.Month == date.Month && od.Day == date.AddDays(1).Day);
        var isJuly = date.Month == 7;

        return isWeekend || isPublicHoliday || isDayBeforePublicHoliday || isJuly;
    }

    private decimal GetTaxAmount(City city, DateTime date)
    {
        var congestionTax = city.CongestionTaxes.FirstOrDefault(ct =>
            date.TimeOfDay >= ct.FromTime && date.TimeOfDay <= ct.ToTime);

        return congestionTax?.Amount ?? 0;
    }
}
