using CourierKata.OrderCalculator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CourierKata.OrderCalculator.Services
{
    // break this service so we can inject discounts
    public class DiscountService : IDiscountService
    {
        public decimal GetDiscount(List<OrderParcel> parcelOrder)
        {
            var discount = 0M;
            var smallParcelMania = GetDiscount(parcelOrder, ParcelType.Small, 4);
            discount += GetAllDiscounts(smallParcelMania, 4);

            var mediumParcelMania = GetDiscount(parcelOrder, ParcelType.Medium, 3);
            discount += GetAllDiscounts(mediumParcelMania, 3);

            var usedParcels = new List<OrderParcel>();
            if (smallParcelMania != null)
            {
                var small = smallParcelMania.SelectMany(x => x).ToList();
                usedParcels.AddRange(small);
            }

            if (mediumParcelMania != null)
            {
                var medium = mediumParcelMania.SelectMany(x => x).ToList();
                usedParcels.AddRange(medium);
            }

            var notUsedParcels = parcelOrder.Where(p => !usedParcels.Any(p2 => ReferenceEquals(p, p2))).ToList();
            var mixedParcelMania = GetDiscount(notUsedParcels, null, 5);
            discount += GetAllDiscounts(mixedParcelMania, 5);

            return discount;
        }

        private IEnumerable<IEnumerable<OrderParcel>> GetDiscount(List<OrderParcel> parcelOrder, ParcelType? type, int freeParcel)
        {
            if (parcelOrder != null)
            {
                var discountParcels = parcelOrder;
                if (type != null)
                {
                    discountParcels = parcelOrder.Where(x => x.Type == type).ToList();
                }

                discountParcels = discountParcels.OrderBy(x => x.Price.Cost).ToList();
                if (discountParcels.Count() > freeParcel - 1)
                {
                    var groupDiscount = discountParcels.Select((item, index) => new { index, item })
                           .GroupBy(x => x.index / freeParcel)
                           .Select(x => x.Select(y => y.item));
                    return groupDiscount;
                }
            }
            return null;
        }

        private decimal GetAllDiscounts(IEnumerable<IEnumerable<OrderParcel>> parcels, int freeParcel)
        {
            var discount = 0M;
            if (parcels != null)
            {
                foreach (var singleParcel in parcels)
                {
                    if (singleParcel.Count() == freeParcel)
                    {
                        discount += singleParcel.FirstOrDefault().Price.Cost;
                    }
                }
            }
            return discount;
        }
    }
}
