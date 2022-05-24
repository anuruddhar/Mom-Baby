
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
using Mobile.Core.Behaviors.Base;
using System.Threading.Tasks;
using Xamarin.Forms;
#endregion

namespace Mobile.Core.Behaviors {
    public class ViewPulsating : BaseAttachedBehavior<ViewPulsating, Xamarin.Forms.View> {
        bool attached;

        protected override void OnAttachedTo(Xamarin.Forms.View bindable) {
            attached = true;
            Task.Run(async () => await AnimateView(bindable));
            base.OnAttachedTo(bindable);
        }

        protected override void OnDetachingFrom(Xamarin.Forms.View bindable) {
            attached = false;
            base.OnDetachingFrom(bindable);
        }

        public async Task AnimateView(Xamarin.Forms.View view) {
            while (attached && (view != null)) {
                var fadeToOpacity = (view.Opacity < 1) ? 1 : 0;
                await view.FadeTo(fadeToOpacity, 1000);
            }
        }
    }
}
