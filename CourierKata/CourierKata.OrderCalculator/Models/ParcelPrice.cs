using System;
using System.Collections.Generic;
using System.Text;

namespace CourierKata.OrderCalculator.Models
{
    public class ParcelPrice : Price
    {
        public decimal SizeCost { get; set; }
    }
}
