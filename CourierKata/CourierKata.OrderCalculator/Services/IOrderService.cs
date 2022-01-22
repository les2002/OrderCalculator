using CourierKata.OrderCalculator.Models;
using System.Collections.Generic;

namespace CourierKata.OrderCalculator.Services
{
    public interface IOrderService
    {
        Order GetOrder(List<Parcel> parcelsDimensions);
    }
}