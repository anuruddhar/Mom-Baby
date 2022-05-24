#region Modification Log
/*------------------------------------------------------------------------------------------------------------------------------------------------- 
    System      -   Mom & Baby
    Client      -   Cardiff Metropolitan University           
    Module      -   Helpers
    Sub_Module  -   

    Copyright   -  Cardiff Metropolitan University 
 
 Modification History:
 ==================================================================================================================================================
 Date              Version      Modify by              Description
 --------------------------------------------------------------------------------------------------------------------------------------------------
21/02/2022         1.0      Anuruddha.Rajapaksha          Initial Version
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
#endregion

namespace Mobile.ViewModels {
    public class DateTimeSelectionPageViewModel : ViewModelBase {

        #region Private Variables
        private DateTime _passedDateTime;
        private DateTime _datetime = Utils.GetCurrentDateTime();
        private DateTime _date = Utils.GetCurrentDateTime();
        private TimeSpan _time = new TimeSpan(DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);
        #endregion

        #region Properties
        public DelegateCommand ConfirmButtonCommand { get; private set; }

        public DateTime Date {
            get { return _date; }
            set {
                SetProperty(ref _date, value);
                SetDateAndTime();
            }
        }

        public DateTime DateAndTime {
            get { return _datetime; }
            set { SetProperty(ref _datetime, value); }
        }

        public TimeSpan Time {
            get { return _time; }
            set {
                SetProperty(ref _time, value);
                SetDateAndTime();
            }
        }
        #endregion

        #region Constructor
        public DateTimeSelectionPageViewModel(INavigationService navigationService,
                                              IEventAggregator eventAggregator,
                                              IUserDialogs dialogs,
                                              ICommonFunction commonFunction)
            : base(navigationService, eventAggregator, dialogs, commonFunction, string.Empty) {
            ConfirmButtonCommand = new DelegateCommand(OnConfirm);
        }
        #endregion

        #region Methods
        protected override async Task OnInitializeAsync(INavigationParameters parameters) {
            try {
                _passedDateTime = (DateTime)parameters[AppConstant.NavigationParameterName.DATE_TIME];
                Date = _passedDateTime;
                Time = new TimeSpan(_passedDateTime.Hour, _passedDateTime.Minute, _passedDateTime.Second);
            } catch (Exception ex) {
                await ShowErrorMessage(true, ex);
            }
        }

        private void SetDateAndTime() {
            DateAndTime = new DateTime(Date.Year, Date.Month, Date.Day, Time.Hours, Time.Minutes, Time.Seconds);
        }

        private void OnConfirm() {
            NavigationParameters navigationParameters = new NavigationParameters();
            navigationParameters.Add(AppConstant.NavigationParameterName.CALL_BACK_REQUIRED, true);
            navigationParameters.Add(AppConstant.NavigationParameterName.CALL_BACK_FUNCTION_CODE, AppConstant.NavigationParameterName.CALL_BACK_DATE_TIME);
            navigationParameters.Add(AppConstant.NavigationParameterName.DATE_TIME_RESULT, DateAndTime);
            NavigationService.GoBackAsync(navigationParameters);
        }
        #endregion

    }
}
