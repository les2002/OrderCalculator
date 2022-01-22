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
        private IPriceService priceService;

        [SetUp]
        public void Setup()
        {
            priceService = new PriceService(2);
            parcelService = new ParcelService(priceService, ParcelSpecData.specData);
        }

        [Test]
        public void SmallParcel()
        {
            var parcel = new Parcel() { Dimensions = new Dimensions() { Height = 9, Length = 9, Width = 9 }, Weight = 1 };
            var testResult = parcelService.GetOrderParcel(parcel);
            Assert.AreEqual(testResult.Price.Cost, 3);
            Assert.AreEqual(testResult.Type, ParcelType.Small);
        }

        [Test]
        public void MediumParcel()
        {
            var parcel = new Parcel() { Dimensions = new Dimensions() { Height = 40, Length = 40, Width = 40 }, Weight = 1 };
            var testResult = parcelService.GetOrderParcel(parcel);
            Assert.AreEqual(testResult.Price.Cost, 8);
            Assert.AreEqual(testResult.Type, ParcelType.Medium);
        }

        [Test]
        public void LargeParcel()
        {
            var parcel = new Parcel() { Dimensions = new Dimensions() { Height = 80, Length = 80, Width = 80 }, Weight = 1 };
            var testResult = parcelService.GetOrderParcel(parcel);
            Assert.AreEqual(testResult.Price.Cost, 15);
            Assert.AreEqual(testResult.Type, ParcelType.Large);
        }

        [Test]
        public void XLParcel()
        {
            var parcel = new Parcel() { Dimensions = new Dimensions() { Height = 101, Length = 101, Width = 101 }, Weight = 1 };
            var testResult = parcelService.GetOrderParcel(parcel);
            Assert.AreEqual(testResult.Price.Cost, 25);
            Assert.AreEqual(testResult.Type, ParcelType.XL);
        }

        [Test]
        public void HeavyParcel()
        {
            var parcel = new Parcel() { Dimensions = new Dimensions() { Height = 101, Length = 101, Width = 101 }, Weight = 51 };
            var testResult = parcelService.GetOrderParcel(parcel);
            Assert.AreEqual(testResult.Price.Cost, 51);
            Assert.AreEqual(testResult.Type, ParcelType.Heavy);
        }
    }
}
