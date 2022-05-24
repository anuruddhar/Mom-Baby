
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
using System.Windows.Input;
using Xamarin.Forms;
#endregion


namespace Mobile.Core.Behaviors {
    public class IsToggledCustomSwitchBehavior : Behavior<CustomSwitch> {

        //public static readonly BindableProperty CommandProperty = BindableProperty.Create<IsToggledSwitchBehavior, ICommand>(p => p.Command, null);
        //public ICommand Command {
        //    get { return (ICommand)GetValue(CommandProperty); }
        //    set { SetValue(CommandProperty, value); }
        //}

        public static readonly BindableProperty CommandProperty = BindableProperty.Create(nameof(Command), typeof(ICommand), typeof(IsToggledSwitchBehavior), null);

        public ICommand Command {
            get { return (ICommand)GetValue(CommandProperty); }
            set { SetValue(CommandProperty, value); }
        }

        public CustomSwitch Bindable { get; private set; }

        //ExtendedEntry control;

        protected override void OnAttachedTo(CustomSwitch bindable) {
            //bindable.BindingContextChanged += (sender, e) =>
            //    BindingContext = bindable.BindingContext;

            //base.OnAttachedTo(bindable);
            //if (null != bindable) {
            //    bindable.BindingContextChanged += OnBindingContextChanged;
            //    bindable.Toggled += this.OnToggled;
            //}
            base.OnAttachedTo(bindable);
            Bindable = bindable;
            Bindable.BindingContextChanged += OnBindingContextChanged;
            Bindable.Toggled += OnToggled;
        }

        protected override void OnDetachingFrom(CustomSwitch bindable) {
            //base.OnDetachingFrom(bindable);
            //if (null != bindable) {
            //    bindable.Toggled -= this.OnToggled;
            //}

            base.OnDetachingFrom(bindable);
            Bindable.BindingContextChanged -= OnBindingContextChanged;
            Bindable.Toggled -= OnToggled;
            Bindable = null;
        }

        private void OnBindingContextChanged(object sender, EventArgs e) {
            OnBindingContextChanged();
            BindingContext = Bindable.BindingContext;
        }


        private void OnToggled(object sender, ToggledEventArgs e) {
            //if (null != this.Command) {
            //    var switcher = ((Switch)sender);
            //    var selected = switcher.BindingContext;
            //    this.Command.Execute(selected);
            //}
            var switcher = ((Switch)sender);
            var selected = switcher.BindingContext;
            Command?.Execute(selected);
        }

    }
}

