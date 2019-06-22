using Newtonsoft.Json.Linq;
using NUnit.Framework;
using PoLaKoSz.hu.Portfolio_hu_API.Deserializers;
using System;

namespace Unit.Deserializers
{
    class SafeJsonDeserializerTests
    {
        private static WrapperAroundSafeJsonDeserializer _parse;

        [OneTimeSetUp]
        public static void OneTimeSetUp()
        {
            _parse = new WrapperAroundSafeJsonDeserializer();
        }

        [TestCase(@"{""name"": ""Tom""}", 0)]
        [TestCase(@"{""name"": null, ""age"": 1}", 1)]
        public void ToStringCanRemoveProperty(string json, int remainingProperties)
        {
            var jObject = JObject.Parse(json);

            var actual = _parse.ToString("name", jObject);

            Assert.AreEqual(remainingProperties, jObject.Count);
        }

        [TestCase(@"{""id"": ""0""}", 0)]
        [TestCase(@"{""id"": 1, ""age"": 1}", 1)]
        public void ToIntCanRemoveProperty(string json, int remainingProperties)
        {
            var jObject = JObject.Parse(json);

            var actual = _parse.ToInt("id", jObject);

            Assert.AreEqual(remainingProperties, jObject.Count);
        }

        [TestCase(@"{""height"": ""0""}", 0)]
        [TestCase(@"{""height"": 3.2, ""age"": 30}", 1)]
        public void ToDoubleCanRemoveProperty(string json, int remainingProperties)
        {
            var jObject = JObject.Parse(json);

            var actual = _parse.ToDouble("height", jObject);

            Assert.AreEqual(remainingProperties, jObject.Count);
        }

        [TestCase(@"{""isAdult"": ""0""}", 0)]
        [TestCase(@"{""isAdult"": false, ""isFemale"": true}", 1)]
        public void ToBoolCanRemoveProperty(string json, int remainingProperties)
        {
            var jObject = JObject.Parse(json);

            var actual = _parse.ToBool("isAdult", jObject);

            Assert.AreEqual(remainingProperties, jObject.Count);
        }

        [TestCase(@"{""birthday"": 0}", 0)]
        [TestCase(@"{""birthday"": 1, ""nameday"": ""10""}", 1)]
        public void FromUnixTimestampCanRemoveProperty(string json, int remainingProperties)
        {
            var jObject = JObject.Parse(json);

            var actual = _parse.FromUnixTimestamp("birthday", jObject);

            Assert.AreEqual(remainingProperties, jObject.Count);
        }

        [TestCase(@"{""oneMonth"": null}", 0)]
        [TestCase(@"{""oneMonth"": 31, ""aYear"": 365}", 1)]
        public void AsDaysCanRemoveProperty(string json, int remainingProperties)
        {
            var jObject = JObject.Parse(json);

            var actual = _parse.AsDays("oneMonth", jObject);

            Assert.AreEqual(remainingProperties, jObject.Count);
        }

        [TestCase(@"{""user"": {""1"": 0}}", 0)]
        [TestCase(@"{""user"": {""1"": null}, ""age"": 10}", 1)]
        public void FromUnnecessaryObjectCanRemoveProperty(string json, int remainingProperties)
        {
            var jObject = JObject.Parse(json);

            var actual = _parse.FromUnnecessaryObject("user", jObject);

            Assert.AreEqual(remainingProperties, jObject.Count);
        }

        [TestCase(@"{""user"": {""1"": null, ""2"": 2}}")]
        [TestCase(@"{""user"": {""1"": null, ""2"": 2}, ""age"": 10}")]
        [TestCase(@"{""user"": {""1"": null, ""2"": 2, ""3"": 3}}")]
        [TestCase(@"{""user"": {""1"": null, ""2"": 2, ""3"": 3}, ""age"": 10}")]
        public void FromUnnecessaryObjectCannotRemoveProperty(string json)
        {
            var jObject = JObject.Parse(json);

            var ex = Assert.Throws<InvalidOperationException>(() => _parse.FromUnnecessaryObject("user", jObject));

            Assert.IsTrue(ex.Message.StartsWith("Cannot remove \"user\" property while it contains multiple children"));
        }

        [TestCase(@"{""a"":1}", 1)]
        [TestCase(@"{""a"":1,""b"":2}", 2)]
        [TestCase(@"{""a"":1,""b"":{""2"":2,""3"":3}}", 3)]
        public void CheckDeserializationSuccessfullThrowsExceptionWhenThereAreRemainingUnparsedProperties(string json, int remainingPropCount)
        {
            var jObject = JObject.Parse(json);

            var ex = Assert.Throws<FormatException>(() => _parse.CheckDeserializationSuccessfull(jObject));

            Assert.AreEqual($"{remainingPropCount} property don't have any deserialization rule! Remaining JSON: >>{json}<<", ex.Message);
        }
    }

    class WrapperAroundSafeJsonDeserializer : SafeJsonDeserializer
    {
        public new string ToString(string propertyName, JObject jObject)
        {
            return base.ToString(propertyName, jObject);
        }

        public new int ToInt(string propertyName, JObject jObject)
        {
            return base.ToInt(propertyName, jObject);
        }

        public new double ToDouble(string propertyName, JObject jObject)
        {
            return base.ToDouble(propertyName, jObject);
        }

        public new bool ToBool(string propertyName, JObject jObject)
        {
            return base.ToBool(propertyName, jObject);
        }

        public new DateTime FromUnixTimestamp(string propertyName, JObject jObject)
        {
            return base.FromUnixTimestamp(propertyName, jObject);
        }

        public new TimeSpan AsDays(string propertyName, JObject jObject)
        {
            return base.AsDays(propertyName, jObject);
        }

        public new int FromUnnecessaryObject(string propertyName, JObject jObject)
        {
            return base.FromUnnecessaryObject(propertyName, jObject);
        }

        public new void CheckDeserializationSuccessfull(JObject container)
        {
            base.CheckDeserializationSuccessfull(container);
        }
    }
}
