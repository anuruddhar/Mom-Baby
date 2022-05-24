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
using Mobile.Models.Common;
using Prism.Commands;
using Prism.Events;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
#endregion

namespace Mobile.ViewModels {
    public class DiscrepancyPageViewModel : ViewModelBase {

        #region Private Variables
        private string _discrepancyMessage;
        private ObservableCollection<Discrepancy> _discrepancies;
        private bool _isConfirmation;
        private bool _isYesNo;
        private string _confirmIcon = AppConstant.AppIcons.ICO_COM_CONFIRM;
        private bool _result;
        private string _callbackFunctionCode;
        #endregion

        #region Properties
        public string DiscrepancyMessage {
            get { return _discrepancyMessage; }
            set { SetProperty(ref _discrepancyMessage, value); }
        }

        public ObservableCollection<Discrepancy> Discrepancies {
            get { return _discrepancies; }
            set { SetProperty(ref _discrepancies, value); }
        }

        public bool IsConfirmation {
            get { return _isConfirmation; }
            set { SetProperty(ref _isConfirmation, value); }
        }

        public string ConfirmIcon {
            get { return _confirmIcon; }
            set { SetProperty(ref _confirmIcon, value); }
        }
        #endregion

        #region Constructor
        public DiscrepancyPageViewModel(INavigationService navigationService,
                                        IEventAggregator eventAggregator,
                                        IUserDialogs dialogs,
                                        ICommonFunction commonFunction)
            : base(navigationService, eventAggregator, dialogs, commonFunction, string.Empty) {
            CancelItemCommand = new DelegateCommand(async () => await OnCancel());
            ConfirmCommand = new DelegateCommand(async () => await OnConfirm());
        }
        #endregion

        #region Methods

        #region Lifecycle hooks & Related Methods
        protected override async Task OnInitializeAsync(INavigationParameters parameters) {
            try {
                if (parameters != null && parameters.Count > 0) {
                    await PopulateData(parameters);
                 }
            } catch (Exception ex) {
                await ShowErrorMessage(true, ex);
            }
        }

        protected override async void OnPageNavigatedTo(INavigationParameters parameters) {
            try {
                 PlayBeep();
            } catch (Exception ex) {
                await ShowErrorMessage(true, ex);
            }
        }


        protected override async void OnPageNavigatedFrom(INavigationParameters parameters) {
            try {
                parameters.Add(AppConstant.NavigationParameterName.CALL_BACK_REQUIRED, _result);
                parameters.Add(AppConstant.NavigationParameterName.MESSAGE_YES_NO, _isYesNo);
                parameters.Add(AppConstant.NavigationParameterName.CALL_BACK_FUNCTION_CODE, _callbackFunctionCode);
            } catch (Exception ex) {
                await ShowErrorMessage(true, ex);
            }
        }

        private Task PopulateData(INavigationParameters parameters) {
            return Task.Run(() => {
                Discrepancies = new ObservableCollection<Discrepancy>();
                Title = (string)parameters[AppConstant.NavigationParameterName.DICREPANCY_TITLE];
                DiscrepancyMessage = (string)parameters[AppConstant.NavigationParameterName.DICREPANCY_MESSAGE];
                var discrepancies = (List<Discrepancy>)parameters[AppConstant.NavigationParameterName.DICREPANCIES];
                IsConfirmation = (bool)parameters[AppConstant.NavigationParameterName.DICREPANCY_IS_CONFIRM];
                _callbackFunctionCode = (string)parameters[AppConstant.NavigationParameterName.CALL_BACK_FUNCTION_CODE];
                _isYesNo = (bool)parameters[AppConstant.NavigationParameterName.MESSAGE_YES_NO];
                if (_callbackFunctionCode == null)
                    _callbackFunctionCode = string.Empty;
                foreach (Discrepancy item in discrepancies) {
                    Discrepancies.Add(item);
                }
            });
        }

        #region PlayBeepSound
        private void PlayBeep() {
            var stream = GetStreamFromFile();
            var audio = Plugin.SimpleAudioPlayer.CrossSimpleAudioPlayer.Current;
            audio.Load(stream);
            audio.Play();
        }
        private Stream GetStreamFromFile() {
            var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(AppConstant.AppSound.BEEP);
            return stream;
        }
        #endregion
        #endregion

        #region Actions
        private async Task OnCancel() {
            try {
                _result = false;
                await NavigationService.GoBackAsync();
            } catch (Exception ex) {
                await ShowErrorMessage(true, ex);
            }
        }

        private async Task OnConfirm() {
            try {
                _result = true;
                await NavigationService.GoBackAsync();
            } catch (Exception ex) {
                await ShowErrorMessage(true, ex);
            }
        }
        #endregion

        #endregion

    }
}
