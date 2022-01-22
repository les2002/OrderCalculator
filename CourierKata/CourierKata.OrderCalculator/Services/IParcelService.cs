using CourierKata.OrderCalculator.Models;

namespace CourierKata.OrderCalculator.Services
{
    public interface IParcelService
    {
        OrderParcel GetOrderParcel(Parcel parcel);
    }
}