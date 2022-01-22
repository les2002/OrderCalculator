using CourierKata.OrderCalculator.Models;
using CourierKata.OrderCalculator.Services;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CourierKata.OrderCalculator.Tests
{
    public class PriceServiceTest
    {
        private IPriceService priceService;

        [SetUp]
        public void Setup()
        {
            priceService = new PriceService(2);
        }

        [Test]
        public void SmallParcel()
        {
            var parcel = new OrderParcel() { Dimensions = new Dimensions() { Height = 9, Length = 9, Width = 9 }, Weight = 1 };
            var pricing = ParcelSpecData.specData.FirstOrDefault(x => x.Type == ParcelType.Small).Pricing;
            var testResult = priceService.GetParcelPrice(parcel, pricing);
            Assert.AreEqual(testResult.Cost, pricing.Cost);
            Assert.AreEqual(testResult.Currency, pricing.Currency);
        }

        [Test]
        public void MediumParcel()
        {
            var parcel = new OrderParcel() { Dimensions = new Dimensions() { Height = 40, Length = 40, Width = 40 }, Weight = 1 };
            var pricing = ParcelSpecData.specData.FirstOrDefault(x => x.Type == ParcelType.Medium).Pricing;
            var testResult = priceService.GetParcelPrice(parcel, pricing);
            Assert.AreEqual(testResult.Cost, pricing.Cost);
            Assert.AreEqual(testResult.Currency, pricing.Currency);
        }

        [Test]
        public void LargeParcel()
        {
            var parcel = new OrderParcel() { Dimensions = new Dimensions() { Height = 80, Length = 80, Width = 80 }, Weight = 1 };
            var pricing = ParcelSpecData.specData.FirstOrDefault(x => x.Type == ParcelType.Large).Pricing;
            var testResult = priceService.GetParcelPrice(parcel, pricing);
            Assert.AreEqual(testResult.Cost, pricing.Cost);
            Assert.AreEqual(testResult.Currency, pricing.Currency);
        }

        [Test]
        public void XLParcel()
        {
            var parcel = new OrderParcel() { Dimensions = new Dimensions() { Height = 101, Length = 101, Width = 101 }, Weight = 1 };
            var pricing = ParcelSpecData.specData.FirstOrDefault(x => x.Type == ParcelType.XL).Pricing;
            var testResult = priceService.GetParcelPrice(parcel, pricing);
            Assert.AreEqual(testResult.Cost, pricing.Cost);
            Assert.AreEqual(testResult.Currency, pricing.Currency);
        }

        [Test]
        public void SmallParcelWeight()
        {
            var parcel = new OrderParcel() { Dimensions = new Dimensions() { Height = 9, Length = 9, Width = 9 }, OverWeight = 1 };
            var pricing = ParcelSpecData.specData.FirstOrDefault(x => x.Type == ParcelType.Small).Pricing;
            var testResult = priceService.GetParcelPrice(parcel, pricing);
            Assert.AreEqual(testResult.Cost, 5);
            Assert.AreEqual(testResult.Currency, pricing.Currency);
            Assert.AreEqual(testResult.WeightCost, 2);
        }

        [Test]
        public void MediumParcelWeight()
        {
            var parcel = new OrderParcel() { Dimensions = new Dimensions() { Height = 40, Length = 40, Width = 40 }, OverWeight = 1 };
            var pricing = ParcelSpecData.specData.FirstOrDefault(x => x.Type == ParcelType.Medium).Pricing;
            var testResult = priceService.GetParcelPrice(parcel, pricing);
            Assert.AreEqual(testResult.Cost, 10);
            Assert.AreEqual(testResult.Currency, pricing.Currency);
            Assert.AreEqual(testResult.WeightCost, 2);
        }

        [Test]
        public void LargeParcelWeight()
        {
            var parcel = new OrderParcel() { Dimensions = new Dimensions() { Height = 80, Length = 80, Width = 80 }, OverWeight = 1 };
            var pricing = ParcelSpecData.specData.FirstOrDefault(x => x.Type == ParcelType.Large).Pricing;
            var testResult = priceService.GetParcelPrice(parcel, pricing);
            Assert.AreEqual(testResult.Cost, 17);
            Assert.AreEqual(testResult.Currency, pricing.Currency);
            Assert.AreEqual(testResult.WeightCost, 2);
        }

        [Test]
        public void XLParcelWeight()
        {
            var parcel = new OrderParcel() { Dimensions = new Dimensions() { Height = 101, Length = 101, Width = 101 }, OverWeight = 1 };
            var pricing = ParcelSpecData.specData.FirstOrDefault(x => x.Type == ParcelType.XL).Pricing;
            var testResult = priceService.GetParcelPrice(parcel, pricing);
            Assert.AreEqual(testResult.Cost, 27);
            Assert.AreEqual(testResult.Currency, pricing.Currency);
            Assert.AreEqual(testResult.WeightCost, 2);
        }

        [Test]
        public void OrderPrice()
        {
            var parcels = new List<OrderParcel>();
            var parcel = new OrderParcel() { Dimensions = new Dimensions() { Height = 101, Length = 101, Width = 101 }, Weight = 1, Price = new ParcelPrice() { Cost = 25, Currency = "$" } };
            parcels.Add(parcel);
            var pricing = ParcelSpecData.specData.FirstOrDefault(x => x.Type == ParcelType.XL).Pricing;
            var testResult = priceService.GetOrderPrice(parcels);
            Assert.AreEqual(testResult.Cost, pricing.Cost);
            Assert.AreEqual(testResult.Currency, pricing.Currency);
        }
    }
}
