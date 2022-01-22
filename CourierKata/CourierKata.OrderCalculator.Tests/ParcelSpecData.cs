using CourierKata.OrderCalculator.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CourierKata.OrderCalculator.Tests
{
    public static class ParcelSpecData
    {
        public static List<ParcelSpec> specData = new List<ParcelSpec>()
            {
                new ParcelSpec()
                {
                    Type = ParcelType.Small,
                    Dimensions = new Dimensions() { Height = 10, Length = 10, Width = 10 },
                    Pricing = new SpecPrice() { Currency = "$", Cost = 3, ChargePerKg = 2 },
                    WeightLimit = 1,
                    Selection = Select.AllDimensions
                },
                new ParcelSpec()
                {
                    Type = ParcelType.Medium,
                    Dimensions = new Dimensions() { Height = 50, Length = 50, Width = 50 },
                    Pricing = new SpecPrice() { Currency = "$", Cost = 8, ChargePerKg = 2},
                    WeightLimit = 3,
                    Selection = Select.AllDimensions
                },
                new ParcelSpec()
                {
                    Type = ParcelType.Large,
                    Dimensions = new Dimensions() { Height = 100, Length = 100, Width = 100 },
                    Pricing = new SpecPrice() { Currency = "$", Cost = 15, ChargePerKg = 2},
                    WeightLimit = 6,
                    Selection = Select.AllDimensions
                },
                new ParcelSpec()
                {
                    Type = ParcelType.XL,
                    Dimensions = null,
                    Pricing = new SpecPrice() { Currency = "$", Cost = 25, ChargePerKg = 2},
                    WeightLimit = 10,
                    Selection = Select.AnyDimension
                },
                new ParcelSpec()
                {
                    Type = ParcelType.Heavy,
                    Dimensions = null,
                    Pricing = new SpecPrice() { Currency = "$", Cost = 50, ChargePerKg = 1},
                    WeightLimit = 50,
                    Selection = Select.WeightOnly
                }
            };
    }
}
