using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace PoLaKoSz.Portfolio.Deserializers
{
    /// <summary>
    /// Wrapper around Newtonsoft.Json to deserialize objects more quickly.
    /// </summary>
    public class JsonDeserializer
    {
        /// <summary>
        /// Gets the property's value as a <see cref="string"/>.
        /// </summary>
        /// <param name="propertyName">The desired property's name.</param>
        /// <param name="jObject">The container of the property.</param>
        /// <returns>Non null string.</returns>
        /// <exception cref="FormatException">Occurs when the property with
        /// the supplied name does not exists within the <see cref="JObject"/>
        /// or the value conversation didn't succeeded. The container of the parameter
        /// <see cref="JObject"/> serialized to JSON string will be appended to the
        /// Message.</exception>
        protected virtual string ToString(string propertyName, JObject jObject)
        {
            try
            {
                var jToken = GetProperty(propertyName, jObject);

                var value = GetValue<string>(jToken);

                if (value == null)
                {
                    return string.Empty;
                }
                else
                {
                    return value;
                }
            }
            catch (Exception ex)
            {
                throw new FormatException(WhenExceptionOccur(propertyName, jObject), ex);
            }
        }

        /// <summary>
        /// Gets the property's value as an <see cref="int"/>.
        /// </summary>
        /// <param name="propertyName">The desired property's name.</param>
        /// <param name="jObject">The container of the property.</param>
        /// <returns>Data converted to <see cref="int"/>.</returns>
        /// <exception cref="FormatException">Occurs when the property with
        /// the supplied name does not exists within the <see cref="JObject"/>
        /// or the value conversation didn't succeeded. The container of the parameter
        /// <see cref="JObject"/> serialized to JSON string will be appended to the
        /// Message.</exception>
        protected virtual int ToInt(string propertyName, JObject jObject)
        {
            try
            {
                var jToken = GetProperty(propertyName, jObject);

                if (ToString(propertyName, jObject) == string.Empty)
                {
                    return 0;
                }
                else
                {
                    return GetValue<int>(jToken);
                }
            }
            catch (Exception ex)
            {
                if (ex.Message == WhenExceptionOccur(propertyName, jObject))
                {
                    throw;
                }
                else
                {
                    throw new FormatException(WhenExceptionOccur(propertyName, jObject), ex);
                }
            }
        }

        /// <summary>
        /// Gets the property's value as a <see cref="double"/>.
        /// </summary>
        /// <param name="propertyName">The desired property's name.</param>
        /// <param name="jObject">The container of the property.</param>
        /// <returns>Data converted to <see cref="double"/>.</returns>
        /// <exception cref="FormatException">Occurs when the property with
        /// the supplied name does not exists within the <see cref="JObject"/>
        /// or the value conversation didn't succeeded. The container of the parameter
        /// <see cref="JObject"/> serialized to JSON string will be appended to the
        /// Message.</exception>
        protected virtual double ToDouble(string propertyName, JObject jObject)
        {
            try
            {
                var jToken = GetProperty(propertyName, jObject);

                if (ToString(propertyName, jObject) == string.Empty)
                {
                    return 0;
                }
                else
                {
                    return GetValue<double>(jToken);
                }
            }
            catch (Exception ex)
            {
                throw new FormatException(WhenExceptionOccur(propertyName, jObject), ex);
            }
        }

        /// <summary>
        /// Gets the property's value as a <see cref="bool"/>.
        /// </summary>
        /// <param name="propertyName">The desired property's name.</param>
        /// <param name="jObject">The container of the property.</param>
        /// <returns>Data converted to <see cref="bool"/>.</returns>
        /// <exception cref="FormatException">Occurs when the property with
        /// the supplied name does not exists within the <see cref="JObject"/>
        /// or the value conversation didn't succeeded. The container of the parameter
        /// <see cref="JObject"/> serialized to JSON string will be appended to the
        /// Message.</exception>
        protected virtual bool ToBool(string propertyName, JObject jObject)
        {
            try
            {
                var jToken = GetProperty(propertyName, jObject);

                var stringValue = ToString(propertyName, jObject);

                if (stringValue == "1")
                {
                    return true;
                }
                else if (stringValue == "0" || stringValue == string.Empty)
                {
                    return false;
                }
                else
                {
                    return GetValue<bool>(jToken);
                }
            }
            catch (Exception ex)
            {
                throw new FormatException(WhenExceptionOccur(propertyName, jObject), ex);
            }
        }

        /// <summary>
        /// Gets the property's value as a <see cref="DateTime"/>.
        /// </summary>
        /// <param name="propertyName">The desired property's name.</param>
        /// <param name="jObject">The container of the property.</param>
        /// <returns>UTC <see cref="DateTime"/>.</returns>
        /// <exception cref="FormatException">Occurs when the property with
        /// the supplied name does not exists within the <see cref="JObject"/>
        /// or the value conversation didn't succeeded. The container of the parameter
        /// <see cref="JObject"/> serialized to JSON string will be appended to the
        /// Message.</exception>
        protected virtual DateTime FromUnixTimestamp(string propertyName, JObject jObject)
        {
            try
            {
                var jToken = GetProperty(propertyName, jObject);

                var secondsString = ToString(propertyName, jObject);
                long seconds = 0;

                if (secondsString != string.Empty)
                {
                    seconds = long.Parse(secondsString);
                }

                if (seconds < 0 || secondsString == string.Empty)
                {
                    throw new FormatException($"Value is less than 0 or its an empty string.");
                }

                return new DateTime(1970, 01, 01, 0, 0, 0, 0, DateTimeKind.Utc)
                    .AddSeconds(seconds);
            }
            catch (Exception ex)
            {
                throw new FormatException(WhenExceptionOccur(propertyName, jObject), ex);
            }
        }

        /// <summary>
        /// Gets the property's value as a <see cref="TimeSpan"/>.
        /// </summary>
        /// <param name="propertyName">The desired property's name.</param>
        /// <param name="jObject">The container of the property.</param>
        /// <returns>Non null object.</returns>
        /// <exception cref="FormatException">Occurs when the property with
        /// the supplied name does not exists within the <see cref="JObject"/>
        /// or the value conversation didn't succeeded. The container of the parameter
        /// <see cref="JObject"/> serialized to JSON string will be appended to the
        /// Message.</exception>
        protected virtual TimeSpan AsDays(string propertyName, JObject jObject)
        {
            var days = ToInt(propertyName, jObject);

            return TimeSpan.FromDays(days);
        }

        /// <summary>
        /// Gets the property's value as an <see cref="in"/>.
        /// </summary>
        /// <param name="propertyName">The desired property's name.</param>
        /// <param name="jObject">The container of the property.</param>
        /// <returns>Always 1.</returns>
        /// <exception cref="FormatException">Occurs when the property with
        /// the supplied name does not exists within the <see cref="JObject"/>
        /// or the value conversation didn't succeeded. The container of the parameter
        /// <see cref="JObject"/> serialized to JSON string will be appended to the
        /// Message.</exception>
        protected virtual int FromUnnecessaryObject(string propertyName, JObject jObject)
        {
            try
            {
                var jObj = GetProperty(propertyName, jObject);

                if (jObj.GetType() != typeof(JObject))
                {
                    throw new FormatException($"Container type have to be JObject!");
                }

                return ToInt("1", (JObject)jObj);
            }
            catch (Exception ex)
            {
                throw new FormatException(WhenExceptionOccur(propertyName, jObject), ex);
            }
        }

        /// <summary>
        /// Gets the property as a <see cref="JToken"/>.
        /// </summary>
        /// <param name="propertyName">The desired property's name.</param>
        /// <param name="jObject">The container of the property.</param>
        /// <returns>A <see cref="JToken"/> or an Exception.</returns>
        /// <exception cref="FormatException">Occurs when the property with
        /// the supplied name does not exists within the <see cref="JObject"/>.</exception>
        private JToken GetProperty(string propertyName, JObject jObject)
        {
            if (!jObject.TryGetValue(propertyName, StringComparison.Ordinal, out JToken jToken))
            {
                throw new FormatException($"Could not found \"{propertyName}\" in the JSON!");
            }

            return jToken;
        }

        /// <summary>
        /// Gets the value stored in the JToken.
        /// </summary>
        /// <typeparam name="T">The tpye of the value stored in the JToken.</typeparam>
        /// <param name="jToken">Where the data stored.</param>
        /// <exception cref="FormatException">Occurs when the value conversation
        /// didn't succeeded. The container of the parameter <see cref="JToken"/>
        /// serialized to JSON string will be appended to the Message.</exception>
        private T GetValue<T>(JToken jToken)
        {
            try
            {
                return jToken.Value<T>();
            }
            catch (Exception ex)
            {
                string json = jToken.ToString();

                if (jToken.Parent != null)
                {
                    json = jToken.Parent.ToString();
                }

                throw new FormatException($"Cannot get value from JToken.", ex);
            }
        }

        private string WhenExceptionOccur(string propertyName, JObject container)
        {
            return $"Cannot deserialize \"{propertyName}\" in {container.ToString(Formatting.None)}.";
        }
    }
}
