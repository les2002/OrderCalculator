using CourierKata.OrderCalculator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CourierKata.OrderCalculator.Services
{
    public class ParcelService : IParcelService
    {
        private readonly List<ParcelSpec> specData;

        public ParcelService(List<ParcelSpec> _specData)
        {
            specData = _specData;
        }
        public OrderParcel GetOrderParcel(Parcel parcel)
        {
            var orderParcels = MappParcel(parcel);
            if (orderParcels != null)
            {
                var selectedSpec = SelectSpec(specData, orderParcels);
                if (selectedSpec != null)
                {
                    orderParcels.Type = selectedSpec.Type;
                    orderParcels.Price = new ParcelPrice() { Currency = selectedSpec.Pricing.Currency, Cost = selectedSpec.Pricing.Cost, SizeCost = selectedSpec.Pricing.Cost };
                }
            }

            return orderParcels;
        }

        private OrderParcel MappParcel(Parcel parcelsDimensions)
        {
            if (parcelsDimensions != null)
            {
                var singleParcel = new OrderParcel()
                {
                    Dimensions = parcelsDimensions.Dimensions
                };
                return singleParcel;
            }

            return null;
        }

        private ParcelSpec SelectSpec(List<ParcelSpec> allSpec, Parcel singleParcel)
        {
            if (allSpec == null)
            {
                // return null;
                throw new Exception("No spec to select from");
            }

            if (singleParcel == null || singleParcel.Dimensions == null)
            {
                // throw new Exception();
                return null;
            }

            var selectedSpec = allSpec.Where(x => x.Selection == Select.AllDimensions).FirstOrDefault(x => x.Dimensions.Length > singleParcel.Dimensions.Length && x.Dimensions.Width > singleParcel.Dimensions.Width && x.Dimensions.Height > singleParcel.Dimensions.Height);
            if (selectedSpec == null)
            {
                var maxDimensions = allSpec.FirstOrDefault(x => x.Selection == Select.AnyDimension);
                return maxDimensions;
            }
            return selectedSpec;
        }
    }
}
