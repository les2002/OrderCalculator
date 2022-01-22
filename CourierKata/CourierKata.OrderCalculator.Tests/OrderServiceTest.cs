using CourierKata.OrderCalculator.Models;
using CourierKata.OrderCalculator.Services;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CourierKata.OrderCalculator.Tests
{
    public class OrderServiceTest
    {
        private IOrderService orderService;
        private IParcelService parcelService;

        [SetUp]
        public void Setup()
        {
            parcelService = new ParcelService(ParcelSpecData.specData);
            orderService = new OrderService(parcelService);
        }

        [Test]
        public void OneParcel()
        {
            var parcels = new List<Parcel>();
            var parcel = new Parcel() { Dimensions = new Dimensions() { Height = 9, Length = 9, Width = 9 }};
            parcels.Add(parcel);
            var orderResult = orderService.GetOrder(parcels);
            Assert.AreEqual(orderResult.Price.Cost, 3);
            Assert.AreEqual(orderResult.Price.SpeedyCost, 6);
            Assert.AreEqual(orderResult.Parcels.Count(), 1);
            Assert.AreEqual(orderResult.Parcels.First().Type, ParcelType.Small);
        }

        [Test]
        public void MultipleParcels()
        {
            var parcels = new List<Parcel>();
            var parcel = new Parcel() { Dimensions = new Dimensions() { Height = 40, Length = 40, Width = 40 } };
            parcels.Add(parcel);
            parcel = new Parcel() { Dimensions = new Dimensions() { Height = 80, Length = 80, Width = 80 }};
            parcels.Add(parcel);
            parcel = new Parcel() { Dimensions = new Dimensions() { Height = 101, Length = 101, Width = 101 } };
            parcels.Add(parcel);
            var orderResult = orderService.GetOrder(parcels);
            Assert.AreEqual(orderResult.Price.Cost, 48);
            Assert.AreEqual(orderResult.Price.SpeedyCost, 96);
            Assert.AreEqual(orderResult.Parcels.Count(), 3);
        }
    }
}
