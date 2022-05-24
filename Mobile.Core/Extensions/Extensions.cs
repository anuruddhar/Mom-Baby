
#region Modification Log
/*------------------------------------------------------------------------------------------------------------------------------------------------- 
    System      -   Mom & Baby
    Client      -   Cardiff Metropolitan University           
    Module      -   Mobile.Core
    Sub_Module  -   

    Copyright   -  Cardiff Metropolitan University 
 
 Modification History:
 ==================================================================================================================================================
 Date              Version      Modify by              Description
 --------------------------------------------------------------------------------------------------------------------------------------------------
19/02/2022          1.0      Anuruddha.Rajapaksha          Initial Version
--------------------------------------------------------------------------------------------------------------------------------------------------*/
#endregion

#region Namespace
using Mobile.Core.Attributes;
using Mobile.Core.Helpers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.Serialization;
#endregion


namespace Mobile.Core.Extensions {
    public static class Extensions {

        public static T Clone<T>(this T instance) {
            var json = JsonConvert.SerializeObject(instance);
            return JsonConvert.DeserializeObject<T>(json);
        }

        public static string ToStringValue(this Enum value) {
            Type type = value.GetType();
            FieldInfo fieldInfo = type.GetField(value.ToString());
            StringValueAttribute[] attribs = fieldInfo.GetCustomAttributes(
                typeof(StringValueAttribute), false) as StringValueAttribute[];

            return attribs.Length > 0 ? attribs[0].StringValue : null;
        }

        public static int ToInt(this object value) {
            int result = 0;

            if (value == null) {
                return 0;
            }

            if (value is Enum) {
                return Convert.ToInt32(value);
            }

            if (Int32.TryParse(value.ToString(), out result)) {
                return result;
            }

            return 0;
        }

        public static Single ToSingle(this object value) {
            Single result = 0;
            if (value == null) {
                return 0;
            }

            if (Single.TryParse(value.ToString(), out result)) {
                return result;
            }

            return 0;
        }

        public static bool ToBool(this object value) {
            bool result = false;
            if (value == null) {
                return false;
            }

            //if (bool.TryParse(value.ToString(), out result)) {
            //    return result;
            //}
            result = BoolParser.GetValue(value + "");

            return result;
        }

        public static decimal ToDecimal(this object value) {
            decimal result = decimal.MinValue;
            if (value == null) {
                return result;
            }

            if (decimal.TryParse(value.ToString(), out result)) {
                return Convert.ToDecimal(value);
            }

            return result;
        }



        public static double ToDouble(this object value) {
            double result = double.MinValue;
            if (value == null) {
                return result;
            }

            if (double.TryParse(value.ToString(), out result)) {
                return Convert.ToDouble(value);
            }

            return result;
        }


        public static IEnumerable<TSource> DistinctBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector) {
            HashSet<TKey> seenKeys = new HashSet<TKey>();
            foreach (TSource element in source) {
                if (seenKeys.Add(keySelector(element))) {
                    yield return element;
                }
            }
        }

    }
}
