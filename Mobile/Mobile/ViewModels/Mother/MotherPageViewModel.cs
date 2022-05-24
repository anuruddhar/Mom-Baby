
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
16/03/2022        1.0           Anuruddha.Rajapaksha   		Initial Version
--------------------------------------------------------------------------------------------------------------------------------------------------*/
#endregion

#region Namespace
using Acr.UserDialogs;
using Mobile.Core.Extensions;
using Mobile.Data;
using Mobile.Enum;
using Mobile.FormModel;
using Mobile.Helpers;
using Mobile.Models.Mother;
using Mobile.Services;
using Prism.Commands;
using Prism.Events;
using Prism.Navigation;
using System;
using System.Threading.Tasks;
#endregion

namespace Mobile.ViewModels {

    public class MotherPageViewModel : ViewModelBase {

        #region Private Variables
        private IMotherDataService _motherDataService;
        private IMotherService _motherService;
        private DateTime _dob = Utils.GetCurrentDateTime();
        private DateTime _nextAppointmentDate = Utils.GetCurrentDateTime();
        private TimeSpan _nextAppointmentTime = new TimeSpan(DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);
        private bool _isUpdate = false;
        #endregion

        #region Properties
        public MotherFormModel Model { get; set; }
        public DateTime Dob {
            get { return _dob; }
            set {
                SetProperty(ref _dob, value);
                Model.SelectedDob = _dob;
                Model.Dob.StringVal = _dob.ToString(AppConstant.DatTimeFormat.YYYY_MM_DD);
            }
        }
        public DateTime NextAppointmentDate {
            get { return _nextAppointmentDate; }
            set {
                SetProperty(ref _nextAppointmentDate, value);
                Model.SelectedNextAppointmentDate = _nextAppointmentDate;
                Model.NextAppointmentDate.StringVal = _nextAppointmentDate.ToString(AppConstant.DatTimeFormat.YYYY_MM_DD);
            }
        }
        public TimeSpan NextAppointmentTime {
            get { return _nextAppointmentTime; }
            set {
                SetProperty(ref _nextAppointmentTime, value);
                Model.SelectedNextAppointmentTime = _nextAppointmentTime;
                //Model.NextAppointmentTime.StringVal = _nextAppointmentTime.ToString(AppConstant.DatTimeFormat.HH_mm);
            }
        }

        #endregion

        #region Constructor
        public MotherPageViewModel(INavigationService navigationService,
                                                              IEventAggregator eventAggregator,
                                                              IUserDialogs dialogs,
                                                              ICommonFunction commonFunction,
                                                              IMotherDataService motherDataService,
                                                              IMotherService motherService)
            : base(navigationService, eventAggregator, dialogs, commonFunction, Message.CAP_MOTHER) {

            IsSubModuleMainPage = true;
            _motherDataService = motherDataService;
            _motherService = motherService;

            FloatingButtonIcon = AppConstant.AppIcons.ICO_COM_CONFIRM_FLOATING;
            FloatingButtonCommand = new DelegateCommand(async () => await OnConfirm());

            Model = new MotherFormModel();

        }
        #endregion

        #region Methods

        protected override async Task OnInitializeAsync(INavigationParameters parameters) {
            try {

                if (parameters[AppConstant.NavigationParameterName.TITLE] != null) {
                    Title = L10n.Localize(((string)parameters[AppConstant.NavigationParameterName.TITLE]), "");
                }

                if (parameters[AppConstant.NavigationParameterName.DATA] != null) {
                    Mother data = (Mother)parameters[AppConstant.NavigationParameterName.DATA];
                    if (data != null) {
                        Model = InitAutoMapper.Initialize().Map<MotherFormModel>(data);

                        this.Dob = Model.SelectedDob;
                        this.NextAppointmentTime = new TimeSpan(Model.SelectedNextAppointmentDate.Hour, Model.SelectedNextAppointmentDate.Minute, Model.SelectedNextAppointmentDate.Second);
                        this.NextAppointmentDate = Model.SelectedNextAppointmentDate;

                        _isUpdate = true;
                    }
                }

            } catch (Exception ex) {
                await ShowErrorMessage(true, ex);
            }
        }

        #region Event Handler
        private async Task OnConfirm() {
            try {
                lock (_lockObject) {
                    if (_isRunning) { return; } else { _isRunning = true; }
                }

                await OnConfirmed();

                _isRunning = false;
            } catch (Exception ex) {
                await ShowErrorMessage(true, ex);
            }
        }

        private async Task OnConfirmed() {
            Model.IsNotValid = false;
            OnFormSubmitValidate();
            if (!Model.IsNotValid) {
                await ConnectionDecider.Instance.DoProcessing(2, this);
            }
        }
        #endregion

        #region Validation
        private void OnFormSubmitValidate() {
            FirstNameValidate();
            LastNameValidate();
            NicValidate();
            PhoneValidate();
            AddressValidate();
            EmailValidate();
            DobDValidate();
            NextAppoinmentDateValidate();
        }
        private void FirstNameValidate() {
            Model.FirstName.NotValidMessageError = CommonFunction.GetConvertedMessage(Message.MSG_INI_071);
            Model.FirstName.IsNotValid = Model.FirstName.StringVal.IsNullOrEmpty();
            if (Model.FirstName.IsNotValid) { SetModelInValid(); }
        }
        private void LastNameValidate() {
            Model.LastName.NotValidMessageError = CommonFunction.GetConvertedMessage(Message.MSG_INI_071);
            Model.LastName.IsNotValid = Model.LastName.StringVal.IsNullOrEmpty();
            if (Model.LastName.IsNotValid) { SetModelInValid(); }
        }
        private void NicValidate() {
            Model.Nic.NotValidMessageError = CommonFunction.GetConvertedMessage(Message.MSG_INI_071);
            Model.Nic.IsNotValid = Model.Nic.StringVal.IsNullOrEmpty();
            if (Model.Nic.IsNotValid) { SetModelInValid(); }
        }
        private void PhoneValidate() {
            Model.Phone.NotValidMessageError = CommonFunction.GetConvertedMessage(Message.MSG_INI_071);
            Model.Phone.IsNotValid = Model.Phone.StringVal.IsNullOrEmpty();
            if (Model.Phone.IsNotValid) { SetModelInValid(); }
        }
        private void AddressValidate() {
            Model.Address.NotValidMessageError = CommonFunction.GetConvertedMessage(Message.MSG_INI_071);
            Model.Address.IsNotValid = Model.Address.StringVal.IsNullOrEmpty();
            if (Model.Address.IsNotValid) { SetModelInValid(); }
        }
        private void EmailValidate() {
            Model.Email.NotValidMessageError = CommonFunction.GetConvertedMessage(Message.MSG_INI_071);
            Model.Email.IsNotValid = Model.Email.StringVal.IsNullOrEmpty();
            if (Model.Email.IsNotValid) { SetModelInValid(); }
        }
        private void DobDValidate() {
            if (!CommonFunction.ValidateFutureDate(Model.SelectedDob)) {
                Model.Dob.IsNotValid = true;
                Model.Dob.NotValidMessageError = CommonFunction.GetConvertedMessage(Message.MSG_INI_070);
                DisplayMessage(MessageType.Message, Message.CAP_LOGIN, Message.MSG_INI_070);
            } else {
                Model.Dob.IsNotValid = false;
            }
            if (Model.Dob.IsNotValid) { SetModelInValid(); }
        }
        private void NextAppoinmentDateValidate() {
            if (!CommonFunction.ValidatePastDate(Model.SelectedNextAppointmentDate)) {
                Model.NextAppointmentDate.IsNotValid = true;
                Model.NextAppointmentDate.NotValidMessageError = CommonFunction.GetConvertedMessage(Message.MSG_INI_069);
                DisplayMessage(MessageType.Message, Message.CAP_LOGIN, Message.MSG_INI_069);
            } else {
                Model.NextAppointmentDate.IsNotValid = false;
            }
            if (Model.NextAppointmentDate.IsNotValid) { SetModelInValid(); }
        }
        private void SetModelInValid() {
            Model.IsNotValid = true;
        }
        #endregion

        #region Override
        protected override async void OnPageResume(INavigationParameters parameters) {
            if (IsCallBackRequired(parameters)) {
                await InvokeCallBack(parameters);
            }
        }
        #endregion

        #region CallBack
        private async Task InvokeCallBack(INavigationParameters parameters) {
            string _callBackFunctionCode = (string)parameters[AppConstant.NavigationParameterName.CALL_BACK_FUNCTION_CODE];
            switch (_callBackFunctionCode) {
                case AppConstant.NavigationParameterName.CALL_BACK_SAVE:
                    await NavigationService.GoBackAsync();
                    break;

                default:
                    break;
            }
        }
        #endregion

        #region Navigation

        #endregion

        #region IConnectionDecider Members
        protected async override Task<bool> OnDoOnlineProcessing() {
            try {
                var data = InitAutoMapper.Initialize().Map<Mother>(Model);
                if (!_isUpdate) {
                    await _motherService.InsertItemAsyn(data);
                } else {
                    await _motherService.UpdateItemAsyn(data);
                }
                object[] messageValue = new object[] { string.Empty };
                await DisplayMessage(MessageType.Sucesss, Message.CAP_SAVE, Message.MSG_SAVE, messageValue, false, AppConstant.NavigationParameterName.CALL_BACK_SAVE);
                return true;
            } catch (Exception ex) {
                throw ex;
            }
        }
        protected async override Task<bool> OnDoOfflineProcessing() {
            try {
                var data = InitAutoMapper.Initialize().Map<Mother>(Model);
                if (!_isUpdate) {
                    await _motherDataService.InsertItemAsyn(data);
                } else {
                    await _motherDataService.UpdateItemAsyn(data);
                }

                object[] messageValue = new object[] { string.Empty };
                await DisplayMessage(MessageType.Warning, Message.CAP_SAVE, Message.MSG_SAVE_LOCALLY, messageValue, false, AppConstant.NavigationParameterName.CALL_BACK_SAVE);
                return true;
            } catch (Exception ex) {
                throw ex;
            }
        }
        #endregion

        #endregion
    }

}
