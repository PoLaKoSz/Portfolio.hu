using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace PoLaKoSz.Portfolio.Deserializers
{
    /// <summary>
    /// Class to detect when a new property appeard in
    /// the deserializable JSON string.
    /// </summary>
    public class SafeJsonDeserializer : JsonDeserializer
    {
        /// <summary>
        /// Gets the property's value as a <see cref="string"/>.
        /// </summary>
        /// <param name="propertyName">The desired property's name.</param>
        /// <param name="jObject">The container of the property.</param>
        /// <returns>Non null string.</returns>
        /// <exception cref="FormatException" />
        protected override string ToString(string propertyName, JObject jObject)
        {
            var value = base.ToString(propertyName, jObject);

            Remove(propertyName, jObject);

            return value;
        }

        /// <summary>
        /// Gets the property's value as a <see cref="int"/>.
        /// </summary>
        /// <param name="propertyName">The desired property's name.</param>
        /// <param name="jObject">The container of the property.</param>
        /// <returns>Non null string.</returns>
        /// <exception cref="FormatException" />
        protected override int FromUnnecessaryObject(string propertyName, JObject jObject)
        {
            var value = base.FromUnnecessaryObject(propertyName, jObject);

            var jProperty = jObject.Property(propertyName);

            RemoveObject(propertyName, jObject);

            return value;
        }

        /// <summary>
        /// Removes the property from the given <see cref="JObject"/>.
        /// </summary>
        /// <param name="propertyName">Name of the property.</param>
        /// <param name="jObject">The container of the property.</param>
        /// <exception cref="JsonSerializationException">Occurs when
        /// the property can not be removed from the <see cref="JObject"/>.</exception>
        protected void Remove(string propertyName, JObject jObject)
        {
            jObject.Remove(propertyName);

            if (jObject.Property(propertyName) != null)
            {
                throw new InvalidOperationException(
                    $"Couldn't remove \"{propertyName}\" property from JSON ({AsString(jObject)}).");
            }
        }

        /// <summary>
        /// Removes the property from the given <see cref="JObject"/>.
        /// </summary>
        /// <param name="name">Name of the proeprty.</param>
        /// <param name="jObject">The container of the property.</param>
        /// <exception cref="JsonSerializationException">Occurs when
        /// the property can not be removed from the <see cref="JObject"/>.</exception>
        protected void RemoveObject(string name, JObject jObject)
        {
            var jProperty = (JObject)jObject.SelectToken(name);

            if (jProperty.Type == JTokenType.Object && jProperty.Count != 0)
            {
                throw new InvalidOperationException(
                    $"Cannot remove \"{name}\" property while it contains multiple children ({AsString(jObject)}).");
            }

            Remove(name, jObject);
        }

        /// <summary>
        /// Validate the deserialization rules that no property missed.
        /// </summary>
        /// <param name="container">Should be the full JSON response
        /// from the API.</param>
        /// <exception cref="FormatException" />
        protected void CheckDeserializationSuccessfull(JObject container)
        {
            if (container.Count != 0)
            {
                int childCount = CountChildrend(container);

                throw new FormatException(
                    $"{childCount} property don't have any deserialization rule! Remaining JSON: >>{AsString(container)}<<");
            }
        }

        private int CountChildrend(JObject jObject)
        {
            if (jObject.Count == 0)
            {
                return 0;
            }

            int count = 0;

            foreach (var child in jObject.Properties())
            {
                if (child.First.Type == JTokenType.Object)
                {
                    count += CountChildrend((JObject)child.First);
                }
                else
                {
                    count++;
                }
            }

            return count;
        }

        private string AsString(JObject jObject) => jObject.ToString(Formatting.None);
    }
}
