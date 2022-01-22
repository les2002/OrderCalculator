using System;
using System.Collections.Generic;
using System.Text;

namespace CourierKata.OrderCalculator.Models
{
    public class OrderPrice : Price
    {
        public decimal SpeedyCost { get; set; }
        public decimal Discount { get; set; }
    }
}
