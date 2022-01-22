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
                    Pricing = new Price() { Currency = "$", Cost = 3},
                    Selection = Select.AllDimensions
                },
                new ParcelSpec()
                {
                    Type = ParcelType.Medium,
                    Dimensions = new Dimensions() { Height = 50, Length = 50, Width = 50 },
                    Pricing = new Price() { Currency = "$", Cost = 8},
                    Selection = Select.AllDimensions
                },
                new ParcelSpec()
                {
                    Type = ParcelType.Large,
                    Dimensions = new Dimensions() { Height = 100, Length = 100, Width = 100 },
                    Pricing = new Price() { Currency = "$", Cost = 15},
                    Selection = Select.AllDimensions
                },
                new ParcelSpec()
                {
                    Type = ParcelType.XL,
                    Dimensions = null,
                    Pricing = new Price() { Currency = "$", Cost = 25},
                    Selection = Select.AnyDimension
                }
            };
    }
}
