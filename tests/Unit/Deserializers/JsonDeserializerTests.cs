using Newtonsoft.Json.Linq;
using NUnit.Framework;
using PoLaKoSz.Portfolio.Deserializers;
using System;

namespace Unit.Deserializers
{
    class JsonDeserializerTests
    {
        private static WrapperAroundJsonDeserializer _parse;

        [OneTimeSetUp]
        public static void OneTimeSetUp()
        {
            _parse = new WrapperAroundJsonDeserializer();
        }

        [TestCase(@"{""user"":{}}")]
        [TestCase(@"{""user"":[]}")]
        public void ToStringThrowsFormatExceptionWhenValue(string json)
        {
            var ex = Assert.Throws<FormatException>(() => _parse.AsString(json, "user"));

            Assert.AreEqual($"Cannot deserialize \"user\" in {json}.", ex.Message);
            Assert.AreEqual(3, DepthOf(ex), "Number of Exceptions.");
        }

        [TestCase(@"{""user"": null}", "")]
        [TestCase(@"{""user"": 0}", "0")]
        [TestCase(@"{""user"": 0.12}", "0.12")]
        [TestCase(@"{""user"": ""Tom""}", "Tom")]
        public void ToStringReturnsStringWhenValue(string json, string expected)
        {
            var actual = _parse.AsString(json, "user");

            Assert.AreEqual(expected, actual);
        }

        [TestCase(@"{""user"":{}}")]
        [TestCase(@"{""user"":[]}")]
        public void ToIntThrowsFormatExceptionWhenValue(string json)
        {
            var ex = Assert.Throws<FormatException>(() => _parse.AsInt(json, "user"));

            Assert.AreEqual($"Cannot deserialize \"user\" in {json}.", ex.Message);
            Assert.AreEqual(3, DepthOf(ex), "Number of InnerException(s).");
        }

        [TestCase(@"{""user"": null}", 0)]
        [TestCase(@"{""user"": """"}", 0)]
        [TestCase(@"{""user"": 0}", 0)]
        [TestCase(@"{""user"": 1}", 1)]
        [TestCase(@"{""user"": 2.2222}", 2)]
        public void ToIntReturnsCorrectValueWhen(string json, int expected)
        {
            var actual = _parse.AsInt(json, "user");

            Assert.AreEqual(expected, actual);
        }

        [TestCase(@"{""user"":{}}")]
        [TestCase(@"{""user"":[]}")]
        public void ToDoubleThrowsFormatExceptionWhenValue(string json)
        {
            var ex = Assert.Throws<FormatException>(() => _parse.AsDoule(json, "user"));

            Assert.AreEqual($"Cannot deserialize \"user\" in {json}.", ex.Message);
            Assert.AreEqual(4, DepthOf(ex), "Number of InnerException(s).");
        }

        [TestCase(@"{""user"": null}", 0d)]
        [TestCase(@"{""user"": """"}", 0d)]
        [TestCase(@"{""user"": 0}", 0)]
        [TestCase(@"{""user"": 1}", 1)]
        [TestCase(@"{""user"": 2.2}", 2.2)]
        [TestCase(@"{""user"": ""0""}", 0)]
        [TestCase(@"{""user"": ""3.3""}", 3.3)]
        public void ToDoubleReturnsCorrectValueWhen(string json, double expected)
        {
            var actual = _parse.AsDoule(json, "user");

            Assert.AreEqual(expected, actual);
        }

        [TestCase(@"{""user"":{}}")]
        [TestCase(@"{""user"":[]}")]
        public void ToBoolThrowsFormatExceptionWhenValue(string json)
        {
            var ex = Assert.Throws<FormatException>(() => _parse.AsBool(json, "user"));

            Assert.AreEqual($"Cannot deserialize \"user\" in {json}.", ex.Message);
            Assert.AreEqual(4, DepthOf(ex), "Number of InnerException(s).");
        }

        [TestCase(@"{""user"": null}", false)]
        [TestCase(@"{""user"": """"}", false)]
        [TestCase(@"{""user"": 0}", false)]
        [TestCase(@"{""user"": 1}", true)]
        [TestCase(@"{""user"": ""0""}", false)]
        [TestCase(@"{""user"": ""1""}", true)]
        public void ToBoolReturnsCorrectValueWhen(string json, bool expected)
        {
            var actual = _parse.AsBool(json, "user");

            Assert.AreEqual(expected, actual);
        }

        [TestCase(@"{""user"":{}}")]
        [TestCase(@"{""user"":[]}")]
        [TestCase(@"{""user"":-1}")]
        [TestCase(@"{""user"":null}")]
        public void FromUnixTimestampThrowsFormatExceptionWhenValue(string json)
        {
            var ex = Assert.Throws<FormatException>(() => _parse.AsUnixTimestamp(json, "user"));

            Assert.AreEqual($"Cannot deserialize \"user\" in {json}.", ex.Message);
        }

        [TestCase(@"{""user"": 1561052014}", 1561052014)]
        [TestCase(@"{""user"": ""1561052014""}", 1561052014)]
        public void FromUnixTimestampReturnsCorrectValueWhen(string json, long seconds)
        {
            var expected = DateTimeOffset.FromUnixTimeSeconds(seconds).UtcDateTime;

            var actual = _parse.AsUnixTimestamp(json, "user");

            Assert.AreEqual(expected, actual);
        }

        [TestCase(@"{""user"":{}}", typeof(JObject))]
        [TestCase(@"{""user"":[]}", typeof(JArray))]
        public void AsDaysThrowsFormatExceptionWhenValue(string json, Type invalidType)
        {
            var ex = Assert.Throws<FormatException>(() => _parse.AsDays(json, "user"));

            Assert.AreEqual($"Cannot deserialize \"user\" in {json}.", ex.Message);
            TestRootCauseOf(ex, invalidType);
        }

        [TestCase(@"{""user"": null}", 0)]
        [TestCase(@"{""user"": """"}", 0)]
        [TestCase(@"{""user"": 0}", 0)]
        [TestCase(@"{""user"": 1}", 1)]
        public void AsDaysReturnsCorrectValueWhen(string json, int expectedDays)
        {
            var expected = TimeSpan.FromDays(expectedDays);

            var actual = _parse.AsDays(json, "user");

            Assert.AreEqual(expected, actual);
        }

        [TestCase(@"{""user"":{}}")]
        [TestCase(@"{""user"":[]}")]
        [TestCase(@"{""user"":{""0"":-2}}")]
        [TestCase(@"{""user"":null}")]
        [TestCase(@"{""user"":""""}")]
        public void FromUnnecessaryObjectThrowsFormatExceptionWhen(string json)
        {
            var ex = Assert.Throws<FormatException>(() => _parse.FromUnnecessaryObject(json, "user"));

            Assert.AreEqual($"Cannot deserialize \"user\" in {json}.", ex.Message);
        }

        [TestCase(@"{""user"": {1:-2}}", -2)]
        [TestCase(@"{""user"": {1:null}}", 0)]
        [TestCase(@"{""user"": {1:11}}", 11)]
        [TestCase(@"{""user"": {1:33, 2:22}}", 33)]
        public void FromUnnecessaryObjectReturnsCorrectValueWhen(string json, int expected)
        {
            var actual = _parse.FromUnnecessaryObject(json, "user");

            Assert.AreEqual(expected, actual);
        }

        private void TestRootCauseOf(FormatException ex, Type currentType)
        {
            Assert.AreEqual(
                $"Cannot cast {currentType} to Newtonsoft.Json.Linq.JToken.",
                ex.InnerException.InnerException.Message);
        }

        private int DepthOf(Exception ex)
        {
            if (ex == null)
                return 0;
            else
                return DepthOf(ex.InnerException) + 1;
        }
    }

    class WrapperAroundJsonDeserializer : JsonDeserializer
    {
        public string AsString(string json, string propertyName)
        {
            var jObject = JObject.Parse(json);

            return base.ToString(propertyName, jObject);
        }

        public int AsInt(string json, string propertyName)
        {
            var jObject = JObject.Parse(json);

            return base.ToInt(propertyName, jObject);
        }

        public double AsDoule(string json, string propertyName)
        {
            var jObject = JObject.Parse(json);

            return base.ToDouble(propertyName, jObject);
        }

        public bool AsBool(string json, string propertyName)
        {
            var jObject = JObject.Parse(json);

            return base.ToBool(propertyName, jObject);
        }

        public DateTime AsUnixTimestamp(string json, string propertyName)
        {
            var jObject = JObject.Parse(json);

            return base.FromUnixTimestamp(propertyName, jObject);
        }

        public TimeSpan AsDays(string json, string propertyName)
        {
            var jObject = JObject.Parse(json);

            return base.AsDays(propertyName, jObject);
        }

        public int FromUnnecessaryObject(string json, string propertyName)
        {
            var jObject = JObject.Parse(json);

            return base.FromUnnecessaryObject(propertyName, jObject);
        }
    }
}
