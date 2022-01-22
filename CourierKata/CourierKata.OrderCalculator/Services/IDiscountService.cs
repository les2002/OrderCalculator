using CourierKata.OrderCalculator.Models;
using System.Collections.Generic;

namespace CourierKata.OrderCalculator.Services
{
    public interface IDiscountService
    {
        decimal GetDiscount(List<OrderParcel> parcelOrder);
    }
}