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
using Xamarin.Forms;
#endregion	  


namespace Mobile.Core.Behaviors {
    public class EntryLengthValidatorBehavior : Behavior<ExtendedEntry> {
        public int MaxLength { get; set; }

        protected override void OnAttachedTo(ExtendedEntry bindable) {
            base.OnAttachedTo(bindable);
            bindable.TextChanged += OnEntryTextChanged;
        }

        protected override void OnDetachingFrom(ExtendedEntry bindable) {
            base.OnDetachingFrom(bindable);
            bindable.TextChanged -= OnEntryTextChanged;
        }

        void OnEntryTextChanged(object sender, TextChangedEventArgs e) {
            var entry = (ExtendedEntry)sender;
            if (entry == null) {
                return;
            }

            if (entry.Text != null) {
                if (entry.Text.Length > this.MaxLength) {
                    string entryText = entry.Text;

                    entryText = entryText.Remove(entryText.Length - 1);

                    entry.Text = entryText;
                }
            }

        }
    }
}
