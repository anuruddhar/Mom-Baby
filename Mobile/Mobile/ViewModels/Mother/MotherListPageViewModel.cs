#region Modification Log
/*------------------------------------------------------------------------------------------------------------------------------------------------- 
   System      -   Mom & Baby
   Client      -   Cardiff Metropolitan University           
   Module      -   Mobile.ViewModel
   Sub_Module  -   

   Copyright   -  Cardiff Metropolitan University 

Modification History:
==================================================================================================================================================
Date              Version        Modify by              Description
--------------------------------------------------------------------------------------------------------------------------------------------------
06/03/2022        1.0           Anuruddha.Rajapaksha   		Initial Version
--------------------------------------------------------------------------------------------------------------------------------------------------*/
#endregion

#region Namespace
using Acr.UserDialogs;
using Mobile.Core.Extensions;
using Mobile.Data;
using Mobile.Enum;
using Mobile.Helpers;
using Mobile.Models.Map;
using Mobile.Models.Mother;
using Prism.Commands;
using Prism.Events;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Tab = SegmentedControl.FormsPlugin.Abstractions;
using XamarinMap = Xamarin.Forms.Maps;
#endregion

namespace Mobile.ViewModels {
    public class MotherListPageViewModel : ViewModelBase {

        #region Private Variables
        private int _time;
        private bool _isListView = true;
        private Mother _selectedItem;
        private ObservableCollection<Mother> _items;
        private CustomMap _customMap;
        private IMotherDataService _motherDataService;
        #endregion

        #region Properties

        public ICommand ItemTappedCommand { get; private set; }
        public ICommand SetCustomMapCommand { get; private set; }
        public ICommand SetTabClickedCommand { get; private set; }
        public CustomMap CustomMap {
            get => _customMap;
            set { SetProperty(ref _customMap, value); }
        }

        public ObservableCollection<Mother> Items {
            get { return _items; }
            set { SetProperty(ref _items, value); }
        }
        public bool IsListView {
            get => _isListView;
            set { SetProperty(ref _isListView, value); }
        }
        #endregion

        #region Constructor
        public MotherListPageViewModel(INavigationService navigationService,
                                                IEventAggregator eventAggregator,
                                                IUserDialogs dialogs,
                                                ICommonFunction commonFunction,
                                                IMotherDataService motherDataService)
            : base(navigationService, eventAggregator, dialogs, commonFunction, Message.CAP_MOTHER) {
            _motherDataService = motherDataService;
            FloatingButtonIcon = AppConstant.AppIcons.ICO_COM_CREATE_ORDER;
            ItemTappedCommand = new DelegateCommand<Mother>(async dc => await OnItemSelected(dc));
            FloatingButtonCommand = new DelegateCommand(async () => await InvokeCreateNew());
            SetTabClickedCommand = new DelegateCommand<Tab.ValueChangedEventArgs>((e) => OnTabClicked(e));
            SetCustomMapCommand = new DelegateCommand<CustomMap>(ap => OnSetCustomMap(ap));
        }
        #endregion

        #region Methods

        #region Lifecycle hooks & Related Methods
        protected override async Task OnInitializeAsync(INavigationParameters parameters) {
            try {
                ShowActivityIndicator(Message.CAP_LOADING);
                await PopulateData(parameters);
                AddModuleSpecificCustomToolBars();
                await DrawOnMap();
                HideActivityIndicator();
            } catch (Exception ex) {
                await ShowErrorMessage(true, ex);
            }
        }

        private void AddModuleSpecificCustomToolBars() {

        }

        protected override async void OnPageResume(INavigationParameters parameters) {
            try {
                if (IsCallBackRequired(parameters)) {
                    await InvokeCallBack(parameters);
                } else {
                    await LoadData();
                }
            } catch (Exception ex) {
                await ShowErrorMessage(true, ex);
            }
        }

        private async Task PopulateData(INavigationParameters parameters) {
            try {
                await LoadData();
            } catch (Exception ex) {
                await ShowErrorMessage(true, ex);
            }
        }

        private async Task LoadData() {
            List<Mother> items = await _motherDataService.GetItemsAsync();
            if (items.IsNotNullOrEmpty()) {
                foreach (var item in items) {
                    item.Image = AppConstant.AppImgesSvg.IMG_LIST_OPENED;
                }
                Items = new ObservableCollection<Mother>(items.OrderBy(x => x.Sequence).OrderBy(x => x.SortOrder).ToList());
            }
        }

        private async Task InvokeCallBack(INavigationParameters parameters) {
            _callBackFunctionCode = (string)parameters[AppConstant.NavigationParameterName.CALL_BACK_FUNCTION_CODE];
            switch (_callBackFunctionCode) {
                case AppConstant.NavigationParameterName.CALL_BACK_CREATE_ACCEPTED:
                    await CallbackCreationAccepted();
                    break;
                case AppConstant.NavigationParameterName.CALL_BACK_REFRESH_DATA:
                    await LoadData();
                    break;
                default:
                    await LoadData();
                    break;
            }
        }
        #endregion

        #region Callback
        private async Task CallbackCreationAccepted() {
            NavigationParameters modifyNavigationParameters = new NavigationParameters();
            modifyNavigationParameters.Add(AppConstant.NavigationParameterName.TITLE, Message.CAP_CREATE_MOTHER);
            await NavigationService.NavigateAsync(AppConstant.Screen.MOM_PAGE, modifyNavigationParameters);
        }

        #endregion

        #region Event Handeler
        private void OnTabClicked(Tab.ValueChangedEventArgs e) {
            switch (e.NewValue) {
                case 0:
                    IsListView = true;
                    break;
                case 1:
                    IsListView = false;
                    break;
            }
        }

        private async Task OnItemSelected(Mother selectedItem) {
            try {
                _selectedItem = selectedItem;
                NavigationParameters modifyNavigationParameters = new NavigationParameters();
                modifyNavigationParameters.Add(AppConstant.NavigationParameterName.TITLE, Message.CAP_MODIFY_MOTHER);
                modifyNavigationParameters.Add(AppConstant.NavigationParameterName.DATA, _selectedItem);
                await NavigationService.NavigateAsync(AppConstant.Screen.MOM_PAGE, modifyNavigationParameters);
            } catch (Exception ex) {
                throw ex;
            }
        }

        private async Task InvokeCreateNew() {
            await DisplayMessage(MessageType.Question, Message.CAP_CREATE_MOTHER, Message.MSG_COM_002, null, true, AppConstant.NavigationParameterName.CALL_BACK_CREATE_ACCEPTED);
        }

        #endregion

        #region Navigation
        private async Task OpenItemDetailsPage() {
            NavigationParameters navigationParameters = new NavigationParameters();
            navigationParameters.Add(AppConstant.NavigationParameterName.DATA, _selectedItem);
            await NavigationService.NavigateAsync(AppConstant.Screen.MOM_PAGE, navigationParameters);
        }
        #endregion

        #region Map
        private async Task DrawOnMap() {
            try {

                if (Items != null) {
                    foreach (var item in Items) {
                        var pin = new CustomPin {
                            Type = XamarinMap.PinType.Place,
                            Position = new XamarinMap.Position(item.Latitude, item.Longitude),
                            Label = $"({item.Sequence}) {item.FirstName} \r\n {item.LastName}",
                            Address = $"{item.Address}",
                            Id = item.MotherId,
                            Url = ""
                        };
                        CustomMap.Pins.Add(pin);
                        CustomMap.CustomPins.Add(pin); // This is for ToolTip Purpose
                    }
                }
                /*
                List<MidWifePosition> positions = await _midWifePositionDataService.GetItemsAsync();
                List<XamarinMap.Position> positions = InitAutoMapper.Initialize().Map<List<XamarinMap.Position>>(positions);
                CustomMap.RouteCoordinates.AddRange(positions);
                */
                CustomMap.MoveToRegion(XamarinMap.MapSpan.FromCenterAndRadius(new XamarinMap.Position(5.951911166, 80.53499817), XamarinMap.Distance.FromMiles(1.0)));
            } catch (Exception ex) {
                throw ex;
            }

        }

        private void OnSetCustomMap(CustomMap customMap) {
            CustomMap = customMap;

        }
        #endregion

        #endregion
    }
}
