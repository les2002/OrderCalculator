using CourierKata.OrderCalculator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CourierKata.OrderCalculator.Services
{
    public class PriceService : IPriceService
    {
        private readonly decimal speedyShipping;

        public PriceService(decimal _speedyShipping)
        {
            speedyShipping = _speedyShipping;
        }

        public ParcelPrice GetParcelPrice(OrderParcel parcel, SpecPrice priceSpec)
        {
            var parcelPrice = new ParcelPrice() { Currency = priceSpec.Currency };
            if (parcel != null && priceSpec != null)
            {
                parcelPrice.SizeCost = priceSpec.Cost;
                parcelPrice.WeightCost = parcel.OverWeight * priceSpec.ChargePerKg;
                parcelPrice.Cost = parcelPrice.SizeCost + parcelPrice.WeightCost;
            }
            return parcelPrice;
        }

        public OrderPrice GetOrderPrice(List<OrderParcel> parcels)
        {
            var orderPrice = new OrderPrice();
            if (parcels == null)
            {
                // throw new Exception();
                return orderPrice;
            }

            if (parcels.Any(x => x.Price == null))
            {
                throw new Exception("Price missing");
            }

            orderPrice.Currency = parcels.FirstOrDefault().Price.Currency;
            orderPrice.Cost = parcels.Sum(x => x.Price.Cost);
            orderPrice.SpeedyCost = orderPrice.Cost * speedyShipping;
            return orderPrice;
        }
    }
}
