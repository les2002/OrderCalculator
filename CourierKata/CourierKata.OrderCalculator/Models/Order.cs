using System;
using System.Collections.Generic;
using System.Text;

namespace CourierKata.OrderCalculator.Models
{
    public class Order
    {
        public List<OrderParcel> Parcels { get; set; }
        public OrderPrice Price { get; set; }
    }
}
