using CourierKata.OrderCalculator.Models;
using CourierKata.OrderCalculator.Services;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace CourierKata.OrderCalculator.Tests
{
    public class ParcelServiceTest
    {
        private IParcelService parcelService;

        [SetUp]
        public void Setup()
        {
            parcelService = new ParcelService();
        }

        [Test]
        public void SmallParcel()
        {
            var parcel = new Parcel() { Dimensions = new Dimensions() { Height = 9, Length = 9, Width = 9 } };
            var testResult = parcelService.GetOrderParcel(parcel);
            Assert.AreEqual(testResult.Price.Cost, 3);
            Assert.AreEqual(testResult.Price.SizeCost, 3);
            Assert.AreEqual(testResult.Type, ParcelType.Small);
        }
    }
}
