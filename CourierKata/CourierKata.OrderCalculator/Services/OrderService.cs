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
        private readonly IPriceService priceService;

        public OrderService(IParcelService _parcelService, IPriceService _priceService)
        {
            parcelService = _parcelService;
            priceService = _priceService;
        }

        public Order GetOrder(List<Parcel> parcelsDimensions)
        {
            var parcels = GetOrderParcels(parcelsDimensions);
            var order = new Order()
            {
                Parcels = parcels,
                Price = GetOrderPrice(parcels)
            };
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

        private OrderPrice GetOrderPrice(List<OrderParcel> parcel)
        {
            return priceService.GetOrderPrice(parcel);
        }
    }
}
