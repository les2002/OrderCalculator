using CourierKata.OrderCalculator.Models;
using System.Collections.Generic;

namespace CourierKata.OrderCalculator.Services
{
    public interface IPriceService
    {
        OrderPrice GetOrderPrice(List<OrderParcel> parcels);
        ParcelPrice GetParcelPrice(OrderParcel parcel, SpecPrice priceSpec);
    }
}