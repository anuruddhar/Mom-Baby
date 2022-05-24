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
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
#endregion


namespace Mobile.Core.Controls {
    public class ExtendedEntry : Entry {
        public static readonly BindableProperty IsBorderErrorVisibleProperty =
            BindableProperty.Create(nameof(IsBorderErrorVisible), typeof(bool), typeof(ExtendedEntry), false, BindingMode.TwoWay);
        public bool IsBorderErrorVisible {
            get { return (bool)GetValue(IsBorderErrorVisibleProperty); }
            set {
                SetValue(IsBorderErrorVisibleProperty, value);
            }
        }

        public static readonly BindableProperty IsKeyBoardDisabledProperty =
            BindableProperty.Create(nameof(IsKeyBoardDisabled), typeof(bool), typeof(ExtendedEntry), false, BindingMode.TwoWay);
        public bool IsKeyBoardDisabled {
            get { return (bool)GetValue(IsKeyBoardDisabledProperty); }
            set {
                SetValue(IsKeyBoardDisabledProperty, value);
            }
        }

        public static readonly BindableProperty BorderErrorColorProperty =
            BindableProperty.Create(nameof(BorderErrorColor), typeof(Xamarin.Forms.Color), typeof(ExtendedEntry), Xamarin.Forms.Color.Transparent, BindingMode.TwoWay);
        public Xamarin.Forms.Color BorderErrorColor {
            get { return (Xamarin.Forms.Color)GetValue(BorderErrorColorProperty); }
            set {
                SetValue(BorderErrorColorProperty, value);
            }
        }

        public static readonly BindableProperty ErrorTextProperty =
            BindableProperty.Create(nameof(ErrorText), typeof(string), typeof(ExtendedEntry), string.Empty, BindingMode.TwoWay);
        public string ErrorText {
            get { return (string)GetValue(ErrorTextProperty); }
            set {
                SetValue(ErrorTextProperty, value);
            }
        }


        public static readonly BindableProperty BorderColorProperty =
            BindableProperty.Create(nameof(BorderColor), typeof(Xamarin.Forms.Color), typeof(ExtendedEntry), Xamarin.Forms.Color.Transparent, BindingMode.TwoWay);

        public Xamarin.Forms.Color BorderColor {
            get { return (Xamarin.Forms.Color)GetValue(BorderColorProperty); }
            set {
                SetValue(BorderColorProperty, value);
            }
        }


        public static readonly BindableProperty BorderRadiousProperty =
                BindableProperty.Create(nameof(BorderRadious), typeof(int), typeof(ExtendedEntry), 3, BindingMode.TwoWay);

        public int BorderRadious {
            get { return (int)GetValue(BorderRadiousProperty); }
            set {
                SetValue(BorderRadiousProperty, value);
            }
        }
    }
}
