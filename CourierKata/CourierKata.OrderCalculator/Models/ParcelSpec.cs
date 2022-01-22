using System;
using System.Collections.Generic;
using System.Text;

namespace CourierKata.OrderCalculator.Models
{
    public class ParcelSpec
    {
        public ParcelType Type { get; set; }
        public Dimensions Dimensions { get; set; }
        public SpecPrice Pricing { get; set; }
        public decimal WeightLimit { get; set; }
        public Select Selection { get; set; }
    }
}
