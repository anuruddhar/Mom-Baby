
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
using Xamarin.Forms;
#endregion

namespace Mobile.Core.Controls {
    public class CustomSwitch : Switch {
        public static readonly BindableProperty SwitchOffColorProperty =
          BindableProperty.Create(nameof(SwitchOffColor),
              typeof(Color), typeof(CustomSwitch),
              Color.Default);

        public Color SwitchOffColor {
            get { return (Color)GetValue(SwitchOffColorProperty); }
            set { SetValue(SwitchOffColorProperty, value); }
        }

        public static readonly BindableProperty SwitchOnColorProperty =
          BindableProperty.Create(nameof(SwitchOnColor),
              typeof(Color), typeof(CustomSwitch),
              Color.Default);

        public Color SwitchOnColor {
            get { return (Color)GetValue(SwitchOnColorProperty); }
            set { SetValue(SwitchOnColorProperty, value); }
        }

        public static readonly BindableProperty SwitchThumbColorProperty =
          BindableProperty.Create(nameof(SwitchThumbColor),
              typeof(Color), typeof(CustomSwitch),
              Color.Default);

        public Color SwitchThumbColor {
            get { return (Color)GetValue(SwitchThumbColorProperty); }
            set { SetValue(SwitchThumbColorProperty, value); }
        }

        public static readonly BindableProperty SwitchThumbImageProperty =
          BindableProperty.Create(nameof(SwitchThumbImage),
              typeof(string),
              typeof(CustomSwitch),
              string.Empty);

        public string SwitchThumbImage {
            get { return (string)GetValue(SwitchThumbImageProperty); }
            set { SetValue(SwitchThumbImageProperty, value); }
        }



    }
}
