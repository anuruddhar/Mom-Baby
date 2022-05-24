#region Modification Log
/*------------------------------------------------------------------------------------------------------------------------------------------------- 
   System      -   Mom & Baby
   Client      -   Cardiff Metropolitan University           
   Module      -   ViewModel
   Sub_Module  -   

   Copyright   -  Cardiff Metropolitan University 

Modification History:
==================================================================================================================================================
Date              Version      		Modify by              					Description
--------------------------------------------------------------------------------------------------------------------------------------------------
12/03/2022         	  1.0         Anuruddha.Rajapaksha   					Initial Version
--------------------------------------------------------------------------------------------------------------------------------------------------*/
#endregion

#region Namespace
using Acr.UserDialogs;
using Mobile.Helpers;
using Prism.Commands;
using Prism.Events;
using Prism.Navigation;
using System;
using System.Threading.Tasks;
using System.Windows.Input;
#endregion

namespace Mobile.ViewModels {
    public class ArrivalTimeSelectPageViewModel : ViewModelBase {

        #region Private Variables
        private int _time;

        #endregion

        #region Properties
        public ICommand FifteenMinutesCommand { get; private set; }
        public ICommand ThirtyMinutesCommand { get; private set; }
        public ICommand FourtyFiveMinutesCommand { get; private set; }
        public ICommand OneHourCommand { get; private set; }

        public int Time {
            get { return _time; }
            set { SetProperty(ref _time, value); }
        }
        #endregion

        #region Constructor
        public ArrivalTimeSelectPageViewModel(INavigationService navigationService,
                                     IEventAggregator eventAggregator,
                                     IUserDialogs dialogs,
                                     ICommonFunction commonFunction)
            : base(navigationService, eventAggregator, dialogs, commonFunction, Message.CAP_TRAVEL_TIME) {
            FloatingButtonIcon = AppConstant.AppIcons.ICO_COM_CONFIRM_FLOATING;
            FloatingButtonCommand = new DelegateCommand(OnCloseScreen);
            FifteenMinutesCommand = new DelegateCommand(OnFifteenMinutes);
            ThirtyMinutesCommand = new DelegateCommand(OnThirtyMinutes);
            FourtyFiveMinutesCommand = new DelegateCommand(OnFourtyFiveMinutes);
            OneHourCommand = new DelegateCommand(OnOneHour);
        }
        #endregion

        #region Event Handlers
        #endregion

        #region Methods

        #region Lifecycle hooks & Related Methods
        protected override async Task OnInitializeAsync(INavigationParameters parameters) {
            try {
                AddModuleSpecificCustomToolBars();
            } catch (Exception ex) {
                await ShowErrorMessage(true, ex);
            }
        }

        private void AddModuleSpecificCustomToolBars() {
        }
        #endregion


        private void OnFifteenMinutes() {
            try {
                Time = 15;
                OnCloseScreen();
            } catch (Exception ex) {
                throw ex;
            }
        }

        private void OnThirtyMinutes() {
            try {
                Time = 30; 
                OnCloseScreen();
            } catch (Exception ex) {
                throw ex;
            }
        }

        private void OnFourtyFiveMinutes() {
            try {
                Time = 45;
                OnCloseScreen();
            } catch (Exception ex) {
                throw ex;
            }
        }

        private void OnOneHour() {
            try {
                Time = 60;
                OnCloseScreen();
            } catch (Exception ex) {
                throw ex;
            }
        }

        private void OnCloseScreen() {
            NavigationParameters navigationParameters = new NavigationParameters();
            if(Time == 0) {
                navigationParameters.Add(AppConstant.NavigationParameterName.CALL_BACK_REQUIRED, false);
            } else {
                navigationParameters.Add(AppConstant.NavigationParameterName.CALL_BACK_REQUIRED, true);
            }
            navigationParameters.Add(AppConstant.NavigationParameterName.CALL_BACK_FUNCTION_CODE, AppConstant.NavigationParameterName.CALL_BACK_ARRIVALTIME_CAPTURED);
            navigationParameters.Add(AppConstant.NavigationParameterName.ARRIVAL_TIME, Time);
            NavigationService.GoBackAsync(navigationParameters);
        }
        #endregion

    }
}
