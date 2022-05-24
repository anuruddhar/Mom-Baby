
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
using System.Linq;
using Xamarin.Forms;
#endregion	 

namespace Mobile.Core.Behaviors.Base {
    public abstract class BaseAttachedBehavior<TBehavior, TBindable> : Behavior<TBindable> where TBindable : BindableObject {
        public static readonly BindableProperty AttachBehaviorProperty
            = BindableProperty.CreateAttached("AttachBehavior", typeof(bool), typeof(TBehavior), false, propertyChanged: OnAttachBehaviorChanged);

        public static bool GetAttachBehavior(BindableObject view) {
            return (bool)view.GetValue(AttachBehaviorProperty);
        }

        public static void SetAttachBehavior(BindableObject view, Object newValue) {
            view.SetValue(AttachBehaviorProperty, (bool)newValue);
        }

        static void OnAttachBehaviorChanged(BindableObject view, Object oldValue, Object newValue) {
            if (view is Xamarin.Forms.View) {
                var behavior = ((Xamarin.Forms.View)view).Behaviors.FirstOrDefault(b => b is TBehavior);
                if ((bool)newValue) {
                    if (behavior == null) {
                        ((Xamarin.Forms.View)view).Behaviors.Add(Activator.CreateInstance<TBehavior>() as Behavior);
                    }
                } else {
                    if (behavior == null) {
                        ((Xamarin.Forms.View)view).Behaviors.Remove(behavior);
                    }
                }
            }
        }
    }
}
