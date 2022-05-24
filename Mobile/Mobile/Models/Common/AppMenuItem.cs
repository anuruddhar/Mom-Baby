
#region Modification Log
/*------------------------------------------------------------------------------------------------------------------------------------------------- 
    System      -   Mom & Baby
    Client      -   Cardiff Metropolitan University           
    Module      -   Mobile.Helpers
    Sub_Module  -   

    Copyright   -  Cardiff Metropolitan University 
 
 Modification History:
 ==================================================================================================================================================
 Date              Version      Modify by              Description
 --------------------------------------------------------------------------------------------------------------------------------------------------
 19/02/2020         1.0      Anuruddha.Rajapaksha          Initial Version
--------------------------------------------------------------------------------------------------------------------------------------------------*/
#endregion

#region Namespace
using Mobile.Events;
using Mobile.Helpers;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Windows.Input;
using Xamarin.Forms;
#endregion
namespace Mobile.Models.Common {
    public class AppMenuItem : BindableBase {

        #region Private Variables
        private string _functionCode;
        private string _menuName;
        private string _icon;
        private string _buttonIcon;
        private int _order;
        private bool _isFavorite;
        private string _screenToOpen;
        private INavigationParameters _iNavigationParameters;
        #endregion

        #region Properties
        public ICommand MenuTappedCommand { get; set; }

        public string FunctionCode {
            get { return _functionCode; }
            set { SetProperty(ref _functionCode, value); }
        }

        public string MenuName {
            get { return _menuName; }
            set { SetProperty(ref _menuName, value); }
        }

        public string Icon {
            get { return _icon; }
            set { SetProperty(ref _icon, value); }
        }

        public string ButtonIcon {
            get { return _buttonIcon; }
            set { SetProperty(ref _buttonIcon, value); }
        }

        public int Order {
            get { return _order; }
            set { SetProperty(ref _order, value); }
        }

        public bool IsFavorite {
            get { return _isFavorite; }
            set {
                SetProperty(ref _isFavorite, value);
                OnPropertyChanged(nameof(FavoriteIcon));
            }
        }

        public string ScreenToOpen {
            get { return _screenToOpen; }
            set { SetProperty(ref _screenToOpen, value); }
        }

        public INavigationParameters INavigationParameters {
            get { return _iNavigationParameters; }
            set { SetProperty(ref _iNavigationParameters, value); }
        }

        public string FavoriteIcon {
            get { return _isFavorite ? AppConstant.AppIcons.ICO_MNU_FAVORITE_SELECT : AppConstant.AppIcons.ICO_MNU_FAVORITE_NOSELECT; }
        }
        #endregion

        #region Constructor
        public AppMenuItem() {
            MenuTappedCommand = new DelegateCommand(OnMenuTapped);
        }
        #endregion

        #region Event Handlers

        #endregion

        #region Methods
        private void OnMenuTapped() {
            try {
                GlobalSetting.Instance.EventAggregator.GetEvent<MenuClickEvent>().Publish(this);
            } catch (Exception ex) {
                throw ex;
            }
        }

        public void OnInvokeTapped(INavigationService navigationservice) {
            try {
                if (ScreenToOpen != string.Empty && ScreenToOpen != null) {
                    navigationservice.NavigateAsync(ScreenToOpen, INavigationParameters);
                }
            } catch (Exception ex) {
                throw ex;
            }
        }

        public void ChangeFavorite() {
            IsFavorite = !IsFavorite;
        }
        #endregion

    }
}
