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
        private readonly IDiscountService discountService;

        public PriceService(decimal _speedyShipping, IDiscountService _discountService)
        {
            speedyShipping = _speedyShipping;
            discountService = _discountService;
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
            orderPrice.Discount = discountService.GetDiscount(parcels);
            orderPrice.Cost = parcels.Sum(x => x.Price.Cost) - orderPrice.Discount;
            orderPrice.SpeedyCost = orderPrice.Cost * speedyShipping;
            
            return orderPrice;
        }
    }
}
