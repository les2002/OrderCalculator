using System;
using System.Collections.Generic;
using System.Text;

namespace CourierKata.OrderCalculator.Models
{
    public class OrderParcel : Parcel
    {
        public ParcelType? Type { get; set; }
        public ParcelPrice Price { get; set; }
        public decimal OverWeight { get; set; }
    }
}
