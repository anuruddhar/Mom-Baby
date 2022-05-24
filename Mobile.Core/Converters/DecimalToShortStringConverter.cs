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
using System;
using System.Globalization;
using Xamarin.Forms;
#endregion	

namespace Mobile.Core.Converters {
    public class DecimalToShortStringConverter : IValueConverter {

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            if (value is decimal) {
                string finalValue = string.Empty;
                string[] splitvalues = System.Convert.ToString(value).Split('.'); ;
                if (splitvalues != null && splitvalues.Length == 1) {
                    finalValue = splitvalues[0];
                } else if (splitvalues != null && splitvalues.Length > 1) {
                    if (System.Convert.ToInt32(splitvalues[1]) > 0) {
                        finalValue = splitvalues[0] + "." + ValidDigits(splitvalues[1]);
                    } else {
                        finalValue = splitvalues[0];
                    }
                }
                return finalValue;
            } else if(value is int) {
                return System.Convert.ToString(value);
            } else {
                return value;
            }
        }

        private string ValidDigits(string tobeDone) {
            string valid = string.Empty;
            for (int i = 0; i < tobeDone.Length; i++) {
                string value = tobeDone.Substring(i, 1);
                if (System.Convert.ToInt32(value) > 0) {
                    valid += value;
                }
            }
            return valid;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
            throw new NotImplementedException();
        }
    }
}
