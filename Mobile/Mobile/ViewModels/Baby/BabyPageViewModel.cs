
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
using Mobile.Models.Baby;
using Mobile.Models.Common;
using Mobile.Models.Mother;
using Mobile.Services;
using Prism.Commands;
using Prism.Events;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
#endregion

namespace Mobile.ViewModels {

    public class BabyPageViewModel : ViewModelBase {

        #region Private Variables
        private IBabyDataService _babyDataService;
        private IBabyService _babyService;
        private IMotherDataService _motherDataService;
        private DateTime _dob = Utils.GetCurrentDateTime();
        private DateTime _nextAppointmentDate = Utils.GetCurrentDateTime();
        private TimeSpan _nextAppointmentTime = new TimeSpan(DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);
        private bool _isUpdate = false;
        #endregion

        #region Properties
        public BabyFormModel Model { get; set; }
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
        public ICommand MotherEntryCommand { get; private set; }
        public ICommand SexEntryCommand { get; private set; }
        #endregion

        #region Constructor
        public BabyPageViewModel(INavigationService navigationService,
                                                              IEventAggregator eventAggregator,
                                                              IUserDialogs dialogs,
                                                              ICommonFunction commonFunction,
                                                              IBabyDataService babyDataService,
                                                              IBabyService babyService,
                                                              IMotherDataService motherDataService)
            : base(navigationService, eventAggregator, dialogs, commonFunction, Message.CAP_BABY) {

            IsSubModuleMainPage = true;
            _babyDataService = babyDataService;
            _babyService = babyService;
            _motherDataService = motherDataService;

            MotherEntryCommand = new DelegateCommand(async () => await OnMotherEntryKeyboardInvoked());
            SexEntryCommand = new DelegateCommand(async () => await OnSexEntryKeyboardInvoked());

            FloatingButtonIcon = AppConstant.AppIcons.ICO_COM_CONFIRM_FLOATING;
            FloatingButtonCommand = new DelegateCommand(async () => await OnConfirm());

            Model = new BabyFormModel();

        }
        #endregion

        #region Methods

        protected override async Task OnInitializeAsync(INavigationParameters parameters) {
            try {
                if (parameters[AppConstant.NavigationParameterName.TITLE] != null) {
                    Title = L10n.Localize(((string)parameters[AppConstant.NavigationParameterName.TITLE]), "");
                }

                if (parameters[AppConstant.NavigationParameterName.DATA] != null) {
                    Baby data = (Baby)parameters[AppConstant.NavigationParameterName.DATA];
                    if (data != null) {
                        Model = InitAutoMapper.Initialize().Map<BabyFormModel>(data);
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

        private async Task OnMotherEntryKeyboardInvoked() {
            await NavigateToMother();
        }
        private async Task OnSexEntryKeyboardInvoked() {
            await NavidateToSex();
        }
        #endregion

        #region Validation
        private void OnFormSubmitValidate() {
            MotherValidate();
            FirstNameValidate();
            LastNameValidate();
            DobDValidate();
            SexValidate();
            NextAppoinmentDateValidate();
        }
        private void MotherValidate() {
            Model.Mother.NotValidMessageError = CommonFunction.GetConvertedMessage(Message.MSG_INI_071);
            Model.Mother.IsNotValid = Model.Mother.StringVal.IsNullOrEmpty();
            if (Model.Mother.IsNotValid) { SetModelInValid(); }
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
        private void SexValidate() {
            Model.Sex.NotValidMessageError = CommonFunction.GetConvertedMessage(Message.MSG_INI_071);
            Model.Sex.IsNotValid = Model.Sex.StringVal.IsNullOrEmpty();
            if (Model.Sex.IsNotValid) { SetModelInValid(); }
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
                case AppConstant.NavigationParameterName.CALL_BACK_DROP_DOWN_DATA_SELECTED:
                    await OnDropDownDataCaptured(parameters);
                    break;

                default:
                    break;
            }
        }

        private async Task OnDropDownDataCaptured(INavigationParameters parameters) {
            DropDown dropDownData = (DropDown)parameters[AppConstant.NavigationParameterName.DROP_DOWN_DATA];
            string dataCategory = (string)parameters[AppConstant.NavigationParameterName.DROP_DOWN_DATA_CATEGORY];
            if (dropDownData != null) {
                switch (dataCategory) {
                    case AppConstant.Parameter.MOTHER:
                        Model.Mother.StringVal = dropDownData.Value;
                        Model.SelectedMotherId = Convert.ToInt32(dropDownData.Id);
                        break;
                    case AppConstant.Parameter.SEX:
                        Model.Sex.StringVal = dropDownData.Value;
                        Model.SelectedMotherId = Convert.ToInt32(dropDownData.Id);
                        break;
                    default:
                        break;
                }
            }
        }

        #endregion

        #region Navigation
        private async Task NavigateToMother() {
            List<DropDown> dropDownData = new List<DropDown>();
            List<Mother> mothers = await _motherDataService.GetItemsAsync();
            foreach (var item in mothers) {
                dropDownData.Add(new DropDown() { Id = item.MotherId.ToString(), Value = $"{item.FirstName}.{item.LastName}" });
            }
            NavigationParameters navigationParameters = new NavigationParameters();
            navigationParameters.Add(AppConstant.NavigationParameterName.DROP_DOWN_DATA_CATEGORY, AppConstant.Parameter.MOTHER);
            navigationParameters.Add(AppConstant.NavigationParameterName.DROP_DOWN_DATA_LIST, dropDownData);
            navigationParameters.Add(AppConstant.NavigationParameterName.TITLE, Message.CAP_MOTHER);
            await NavigationService.NavigateAsync(AppConstant.Screen.DROPDOWN_PAGE, navigationParameters);
        }
        private async Task NavidateToSex() {
            List<DropDown> dropDownData = new List<DropDown>();
            dropDownData.Add(new DropDown() { Id = "1", Value = "Male" });
            dropDownData.Add(new DropDown() { Id = "2", Value = "FeMale" });
            NavigationParameters navigationParameters = new NavigationParameters();
            navigationParameters.Add(AppConstant.NavigationParameterName.DROP_DOWN_DATA_CATEGORY, AppConstant.Parameter.SEX);
            navigationParameters.Add(AppConstant.NavigationParameterName.DROP_DOWN_DATA_LIST, dropDownData);
            navigationParameters.Add(AppConstant.NavigationParameterName.TITLE, Message.CAP_GENDER);
            await NavigationService.NavigateAsync(AppConstant.Screen.DROPDOWN_PAGE, navigationParameters);
        }
        #endregion

        #region IConnectionDecider Members
        protected async override Task<bool> OnDoOnlineProcessing() {
            try {
                var data = InitAutoMapper.Initialize().Map<Baby>(Model);
                if (!_isUpdate) {
                    await _babyService.InsertItemAsyn(data);
                } else {
                    await _babyService.UpdateItemAsyn(data);
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
                var data = InitAutoMapper.Initialize().Map<Baby>(Model);
                if (!_isUpdate) {
                    await _babyDataService.InsertItemAsyn(data);
                } else {
                    await _babyDataService.UpdateItemAsyn(data);
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
