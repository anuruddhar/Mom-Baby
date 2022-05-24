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
using Mobile.Core.Controls;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
#endregion	  


namespace Mobile.Core.Behaviors {
    public class EntryTextChanged : Behavior<ExtendedEntry> {
        public static readonly BindableProperty CommandProperty = BindableProperty.Create<EntryTextChanged, ICommand>(p => p.Command, null);

        public ICommand Command {
            get { return (ICommand)GetValue(CommandProperty); }
            set { SetValue(CommandProperty, value); }
        }

        protected override void OnAttachedTo(ExtendedEntry bindable) {
            bindable.BindingContextChanged += (sender, e) =>
                BindingContext = bindable.BindingContext;

            base.OnAttachedTo(bindable);
            if (null != bindable) {
                bindable.TextChanged += this.OnTextChanged;
            }
        }

        protected override void OnDetachingFrom(ExtendedEntry bindable) {
            base.OnDetachingFrom(bindable);
            if (null != bindable) {
                bindable.TextChanged -= this.OnTextChanged;
            }
        }

        private void OnTextChanged(object sender, TextChangedEventArgs e) {
            if (null != this.Command) {
                this.Command.Execute(e.NewTextValue);
            }
        }
    }
}
