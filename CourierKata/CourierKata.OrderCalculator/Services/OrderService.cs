using CourierKata.OrderCalculator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CourierKata.OrderCalculator.Services
{
    public class OrderService : IOrderService
    {
        private readonly IParcelService parcelService;

        public OrderService(IParcelService _parcelService)
        {
            parcelService = _parcelService;
        }

        public Order GetOrder(List<Parcel> parcelsDimensions)
        {
            var parcels = GetOrderParcels(parcelsDimensions);
            var order = new Order()
            {
                Parcels = parcels,
                Price = new OrderPrice()
            };
            order.Price.Currency = parcels.FirstOrDefault().Price.Currency;
            order.Price.Cost = parcels.Sum(x => x.Price.Cost);
            order.Price.SpeedyCost = order.Price.Cost * 2;
            return order;
        }

        private List<OrderParcel> GetOrderParcels(List<Parcel> parcels)
        {
            var orderParcels = new List<OrderParcel>();
            if (parcels != null)
            {
                foreach (var singleParcel in parcels)
                {
                    var singleOrderParcel = parcelService.GetOrderParcel(singleParcel);
                    orderParcels.Add(singleOrderParcel);
                }
            }
            return orderParcels;
        }
    }
}
