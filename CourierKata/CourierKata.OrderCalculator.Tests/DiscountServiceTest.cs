using CourierKata.OrderCalculator.Models;
using CourierKata.OrderCalculator.Services;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace CourierKata.OrderCalculator.Tests
{
    public class DiscountServiceTest
    {
        private IDiscountService discountService;

        [SetUp]
        public void Setup()
        {
            discountService = new DiscountService();
        }

        [Test]
        public void Medium()
        {
            var parcels = new List<OrderParcel>();
            var parcel = new OrderParcel() { Type = ParcelType.Medium, Price = new ParcelPrice() { Cost = 8, Currency = "$" } };
            parcels.Add(parcel);
            parcel = new OrderParcel() { Type = ParcelType.Medium, Price = new ParcelPrice() { Cost = 8, Currency = "$" } };
            parcels.Add(parcel);
            parcel = new OrderParcel() { Type = ParcelType.Medium, Price = new ParcelPrice() { Cost = 8, Currency = "$" } };
            parcels.Add(parcel);
            parcel = new OrderParcel() { Type = ParcelType.Medium, Price = new ParcelPrice() { Cost = 10, Currency = "$" } };
            parcels.Add(parcel);
            parcel = new OrderParcel() { Type = ParcelType.Medium, Price = new ParcelPrice() { Cost = 10, Currency = "$" } };
            parcels.Add(parcel);
            parcel = new OrderParcel() { Type = ParcelType.Medium, Price = new ParcelPrice() { Cost = 10, Currency = "$" } };
            parcels.Add(parcel);
            var orderResult = discountService.GetDiscount(parcels);
            Assert.AreEqual(orderResult, 18);
        }

        [Test]
        public void Small()
        {
            var parcels = new List<OrderParcel>();
            var parcel = new OrderParcel() { Type = ParcelType.Medium, Price = new ParcelPrice() { Cost = 3, Currency = "$" } };
            parcels.Add(parcel);
            parcel = new OrderParcel() { Type = ParcelType.Medium, Price = new ParcelPrice() { Cost = 3, Currency = "$" } };
            parcels.Add(parcel);
            parcel = new OrderParcel() { Type = ParcelType.Medium, Price = new ParcelPrice() { Cost = 3, Currency = "$" } };
            parcels.Add(parcel);
            parcel = new OrderParcel() { Type = ParcelType.Medium, Price = new ParcelPrice() { Cost = 5, Currency = "$" } };
            parcels.Add(parcel);
            parcel = new OrderParcel() { Type = ParcelType.Medium, Price = new ParcelPrice() { Cost = 5, Currency = "$" } };
            parcels.Add(parcel);
            parcel = new OrderParcel() { Type = ParcelType.Medium, Price = new ParcelPrice() { Cost = 5, Currency = "$" } };
            parcels.Add(parcel);
            var orderResult = discountService.GetDiscount(parcels);
            Assert.AreEqual(orderResult, 8);
        }

        [Test]
        public void LargeAndXL()
        {
            var parcels = new List<OrderParcel>();
            var parcel = new OrderParcel() { Type = ParcelType.Large, Price = new ParcelPrice() { Cost = 15, Currency = "$" } };
            parcels.Add(parcel);
            parcel = new OrderParcel() { Type = ParcelType.Large, Price = new ParcelPrice() { Cost = 15, Currency = "$" } };
            parcels.Add(parcel);
            parcel = new OrderParcel() { Type = ParcelType.Large, Price = new ParcelPrice() { Cost = 15, Currency = "$" } };
            parcels.Add(parcel);
            parcel = new OrderParcel() { Type = ParcelType.XL, Price = new ParcelPrice() { Cost = 25, Currency = "$" } };
            parcels.Add(parcel);
            parcel = new OrderParcel() { Type = ParcelType.XL, Price = new ParcelPrice() { Cost = 25, Currency = "$" } };
            parcels.Add(parcel);
            parcel = new OrderParcel() { Type = ParcelType.XL, Price = new ParcelPrice() { Cost = 25, Currency = "$" } };
            parcels.Add(parcel);
            var orderResult = discountService.GetDiscount(parcels);
            Assert.AreEqual(orderResult, 15);
        }
    }
}
