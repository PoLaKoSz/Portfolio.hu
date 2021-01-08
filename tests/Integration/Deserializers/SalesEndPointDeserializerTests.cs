using System;
using System.Collections.Generic;
using System.Linq;
using Library.Tests.Integration;
using NUnit.Framework;
using PoLaKoSz.hu.Portfolio_hu_API.Deserializers;
using PoLaKoSz.hu.Portfolio_hu_API.Models;

namespace tests.Integration.Deserializers
{
    [TestFixture]
    class SalesEndPointDeserializerTests : TestClassBase
    {
        private static SalesEndPointDeserializer _serializer;

        public SalesEndPointDeserializerTests()
            : base("Sales")
        {
        }

        [OneTimeSetUp]
        public static void OneTimeSetUp()
        {
            _serializer = new SalesEndPointDeserializer();
        }

        [Test]
        public void ParseTableReturnCorrectNumberOfElements()
        {
            string html = GetTestData("active-stock");

            IReadOnlyList<Sale> sales = _serializer.ParseTable(html);

            Assert.That(sales.Count, Is.EqualTo(837));
        }

        [Test]
        public void ParseTableWithoutSalesRowsReturnEmptyCollection()
        {
            string html = GetTestData("inactive-stock");

            IReadOnlyList<Sale> sales = _serializer.ParseTable(html);

            Assert.That(sales.Count(), Is.EqualTo(0));
        }

        [Test]
        public void ParseTableDetectChangeDirection()
        {
            string html = GetTestData("active-stock");

            IEnumerable<Sale> sales = _serializer.ParseTable(html);

            Assert.That(sales.First().ChangeDirection, Is.EqualTo(1), "Up change failed");
            Assert.That(sales.Skip(1).First().ChangeDirection, Is.EqualTo(-1), "Down change failed");
            Assert.That(sales.Skip(2).First().ChangeDirection, Is.EqualTo(0), "Steady direction failed");
        }

        [Test]
        public void ParseTableCheckOneSaleItem()
        {
            string html = GetTestData("active-stock");

            IEnumerable<Sale> sales = _serializer.ParseTable(html);

            Sale third = sales.Skip(2).First();
            Assert.That(third.Time, Is.EqualTo(DateTime.Parse("17:05:27")), "Time");
            Assert.That(third.Price, Is.EqualTo(13_790), "Price");
            Assert.That(third.Change, Is.EqualTo(99.99), "Change");
            Assert.That(third.Count, Is.EqualTo(147_760), "Count");
            Assert.That(third.Value, Is.EqualTo(2_037_610_400), "Value");
        }

        [Test]
        public void ParseTickerSelectorReturnCorrectItems()
        {
            IEnumerable<ShareType> expected = new List<ShareType>()
            {
                new ShareType("4IG"),
                new ShareType("AKKO"),
                new ShareType("AKKO"),
                new ShareType("ALTEO"),
                new ShareType("ANY"),
                new ShareType("APPENINN"),
                new ShareType("AUTOWALLIS"),
                new ShareType("BIF"),
                new ShareType("CIG"),
                new ShareType("CIGPANNONIA"),
                new ShareType("CYBERG"),
                new ShareType("DELTA"),
                new ShareType("DMKER"),
                new ShareType("DUNAHOUSE"),
                new ShareType("EHEP"),
                new ShareType("ENEFI"),
                new ShareType("FINEXT"),
                new ShareType("FINEXT B"),
                new ShareType("FORRAS|OE"),
                new ShareType("FORRAS|T"),
                new ShareType("FUTURAQUA"),
                new ShareType("GLOSTER"),
                new ShareType("GOPD"),
                new ShareType("GSPARK"),
                new ShareType("KARPOT"),
                new ShareType("KPACK"),
                new ShareType("KULCSSOFT"),
                new ShareType("MASTERPLAST"),
                new ShareType("MEGAKRAN"),
                new ShareType("MKBBANK"),
                new ShareType("MOL"),
                new ShareType("MTELEKOM"),
                new ShareType("NORDTELEKOM"),
                new ShareType("NUTEX"),
                new ShareType("OPUS"),
                new ShareType("ORM"),
                new ShareType("ORMESTER"),
                new ShareType("OTP"),
                new ShareType("OTT1"),
                new ShareType("PANNERGY"),
                new ShareType("PENSUM"),
                new ShareType("RABA"),
                new ShareType("RICHTER"),
                new ShareType("SET"),
                new ShareType("SUNDELL"),
                new ShareType("TAKAREKJZB"),
                new ShareType("UBM"),
                new ShareType("WABERERS"),
                new ShareType("ZWACK"),
            };
            string html = GetTestData("active-stock");

            IEnumerable<ShareType> tickers = _serializer.ParseTickerSelector(html);

            Assert.That(tickers, Is.EqualTo(expected));
        }
    }
}
