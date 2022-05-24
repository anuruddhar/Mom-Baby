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
using Mobile.Core.Extensions;
using Mobile.Helpers;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
#endregion	  


namespace Mobile.ViewModels {
    public class CalendarPageViewModel : PopupBaseViewModel {

        #region Private Variables
        private string _year = "";
        private string _category;
        #endregion

        #region Properties
        public ICommand MonthPressCommand { private set; get; }
        public ICommand FiveYearChangeCommand { private set; get; }

        public string Year {
            get { return _year; }
            set { SetProperty(ref _year, value); }
        }
        #endregion

        #region Constructor
        public CalendarPageViewModel(INavigationService navigationService,
                                       IEventAggregator eventAggregator,
                                       IUserDialogs dialogs,
                                       ICommonFunction commonFunction)
        : base(navigationService, eventAggregator, dialogs, commonFunction) {


            Year = DateTime.Now.Year.ToString();

            MonthPressCommand = new Command<string>(
                execute: (string arg) => {
                    NavigationParameters navigationParameters = new NavigationParameters();
                    navigationParameters.Add(AppConstant.NavigationParameterName.CALL_BACK_REQUIRED, true);
                    navigationParameters.Add(AppConstant.NavigationParameterName.CALL_BACK_FUNCTION_CODE, AppConstant.NavigationParameterName.CALL_BACK_CALENDAR_SELECT);
                    navigationParameters.Add(AppConstant.NavigationParameterName.CALENDAR_CATEGORY, _category);
                    navigationParameters.Add(AppConstant.NavigationParameterName.CALENDAR_DATE, $"{arg}/{Year}");
                    navigationParameters.Add(AppConstant.NavigationParameterName.CALENDAR_YEAR, Year);
                    navigationParameters.Add(AppConstant.NavigationParameterName.CALENDAR_MONTH, arg);
                    NavigationService.GoBackAsync(navigationParameters);
                });

            FiveYearChangeCommand = new Command<string>(
            execute: (string arg) => {
                var currentYear = Year.ToInt();
                currentYear += arg.ToInt();
                Year = currentYear.ToString();
            });

        }
        #endregion

        #region Methods

        protected override async Task OnInitializeAsync(INavigationParameters parameters) {
            try {
                _category = (string)parameters[AppConstant.NavigationParameterName.CALENDAR_CATEGORY];
            } catch (Exception ex) {
                await ShowErrorMessage(true, ex);
            }
        }

        #endregion

    }
}
