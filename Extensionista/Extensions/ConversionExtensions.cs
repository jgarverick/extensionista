using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace Extensionista
{
    public static class ConversionExtensions
    {
        /// <summary>
        /// Retrieves a TypeConverter for a given object.
        /// </summary>
        /// <param name="o">The Object variable that will utilize the 
        /// extension method.</param>
        /// <returns>A TypeConverter that corresponds to the supplied variable's type.  If
        /// no specific type can be matched, a generic TypeConverter will be returned.</returns>
        public static TypeConverter GetConverter(this object o)
        {
            return o.GetType().GetConverter();
        }
        /// <summary>
        /// Retrieves a TypeConverter for a given type.
        /// </summary>
        /// <param name="type">The System.Type variable that will utilize the 
        /// extension method.</param>
        /// <returns>A TypeConverter that corresponds to the type supplied.  If
        /// no specific type can be matched, a generic TypeConverter will be returned.</returns>
        public static TypeConverter GetConverter(this Type type)
        {
            if (type.IsEquivalentTo(typeof(string)))
                return new StringConverter();
            else if (type.IsEquivalentTo(typeof(int)))
                return new Int32Converter();
            else if (type.IsEquivalentTo(typeof(Int32)))
                return new Int32Converter();
            else if (type.IsEquivalentTo(typeof(Int16)))
                return new Int16Converter();
            else if (type.IsEquivalentTo(typeof(Int64)))
                return new Int64Converter();
            else if (type.IsEquivalentTo(typeof(Guid)))
                return new GuidConverter();
            else if (type.IsEquivalentTo(typeof(DateTime)))
                return new DateTimeConverter();
            else if (type.IsEquivalentTo(typeof(TimeSpan)))
                return new TimeSpanConverter();
            else if (type.IsEquivalentTo(typeof(bool)))
                return new BooleanConverter();
            else if (type.IsEquivalentTo(typeof(double)))
                return new DoubleConverter();
            else if (type.IsEquivalentTo(typeof(decimal)))
                return new DecimalConverter();
            else
                return new TypeConverter();
        }
        /// <summary>
        /// Converts the supplied object into an object of type T.
        /// </summary>
        /// <typeparam name="T">The type that represents the conversion target type.</typeparam>
        /// <param name="type">The variable of type T that will utilize the 
        /// extension method.</param>
        /// <param name="value">The object to convert.</param>
        /// <returns>An object of type T. If the conversion was successful, the
        /// return object will contain the converted value.  If not, the default value
        /// for the type will be returned.</returns>
        public static T ConvertValue<T>(this T type, object value)
        {
            if (type.GetType().GetConverter().CanConvertFrom(value.GetType()))
                try { return (T)value.ConvertValue<T>(); }
                catch
                {
                    return default(T);
                }

            return default(T);
        }
        /// <summary>
        /// Converts a variable object into an object of the type specified by T.
        /// </summary>
        /// <typeparam name="T">The type that represents the conversion target type.</typeparam>
        /// <param name="value">The Object variable that will utilize the 
        /// extension method.</param>
        /// <returns>An object of type T. If the conversion was successful, the
        /// return object will contain the converted value.  If not, the default value
        /// for the type will be returned.</returns>
        public static T ConvertValue<T>(this object value)
        {
            Type type = typeof(T);
            if (type.GetConverter().CanConvertFrom(value.GetType()))
            {
                return (T)type.GetConverter().ConvertFrom(value);
            }
            else
                return default(T);
        }
    }
}
