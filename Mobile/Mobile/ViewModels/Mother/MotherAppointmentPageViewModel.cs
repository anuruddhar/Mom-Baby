
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
using Mobile.Data.MotherAppoinmentData;
using Mobile.Enum;
using Mobile.FormModel;
using Mobile.Helpers;
using Mobile.Models.Common;
using Mobile.Models.Mother;
using Mobile.Services.MotherAppoinmentService;
using Prism.Commands;
using Prism.Events;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
#endregion

namespace Mobile.ViewModels {

    public class MotherAppointmentPageViewModel : ViewModelBase {

        #region Private Variables
        private IMotherAppoinmentDataService _motherAppoinmentDataService;
        private IMotherAppoinmentService _motherAppoinmentService;
        private IMotherDataService _motherDataService;

        private DateTime _nextAppointmentDate = Utils.GetCurrentDateTime();
        private TimeSpan _nextAppointmentTime = new TimeSpan(DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);
        #endregion

        #region Properties
        public MotherAppoinmentFormModel Model { get; set; }


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
                Model.NextAppointmentTime.StringVal = _nextAppointmentTime.ToString(AppConstant.DatTimeFormat.HH_mm);
            }
        }

        public ICommand MotherEntryCommand { get; private set; }
        #endregion

        #region Constructor
        public MotherAppointmentPageViewModel(INavigationService navigationService,
                                                              IEventAggregator eventAggregator,
                                                              IUserDialogs dialogs,
                                                              ICommonFunction commonFunction,
                                                              IMotherAppoinmentDataService motherAppoinmentDataService,
                                                              IMotherAppoinmentService motherAppoinmentService,
                                                              IMotherDataService motherDataService)
            : base(navigationService, eventAggregator, dialogs, commonFunction, Message.CAP_MOM_HEALTH) {

            IsSubModuleMainPage = true;
            _motherAppoinmentDataService = motherAppoinmentDataService;
            _motherAppoinmentService = motherAppoinmentService;
            _motherDataService = motherDataService;

            MotherEntryCommand = new DelegateCommand(async () => await OnMotherEntryKeyboardInvoked());

            FloatingButtonIcon = AppConstant.AppIcons.ICO_COM_CONFIRM_FLOATING;
            FloatingButtonCommand = new DelegateCommand(async () => await OnConfirm());

            Model = new MotherAppoinmentFormModel();

        }
        #endregion

        #region Methods

        protected override async Task OnInitializeAsync(INavigationParameters parameters) {
            try {
                Mother data = (Mother)parameters[AppConstant.NavigationParameterName.DATA];
                if (data != null) {
                    Model.Mother.StringVal = data.FullName;

                    //this.NextAppointmentDate = DateTime.Now.AddDays(14);

                    this.NextAppointmentTime = new TimeSpan(Model.SelectedNextAppointmentDate.Hour, Model.SelectedNextAppointmentDate.Minute, Model.SelectedNextAppointmentDate.Second);
                    this.NextAppointmentDate = Model.SelectedNextAppointmentDate;
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
                await NavigateToSignature();
            }
        }

        private async Task OnMotherEntryKeyboardInvoked() {
            await NavigateToMother();
        }
        #endregion

        #region Validation
        private void OnFormSubmitValidate() {
            MotherValidate();
            HealthConditionValidate();
            WeightValidate();
            BloodPressureValidate();
            GlucouseLevelValidate();
            NextAppoinmentDateValidate();
        }
        private void MotherValidate() {
            Model.Mother.NotValidMessageError = CommonFunction.GetConvertedMessage(Message.MSG_INI_071);
            Model.Mother.IsNotValid = Model.Mother.StringVal.IsNullOrEmpty();
            if (Model.Mother.IsNotValid) { SetModelInValid(); }
        }
        private void HealthConditionValidate() {
            Model.HealthCondition.NotValidMessageError = CommonFunction.GetConvertedMessage(Message.MSG_INI_071);
            Model.HealthCondition.IsNotValid = Model.HealthCondition.StringVal.IsNullOrEmpty();
            if (Model.HealthCondition.IsNotValid) { SetModelInValid(); }
        }
        private void WeightValidate() {
            Model.Weight.NotValidMessageError = CommonFunction.GetConvertedMessage(Message.MSG_INI_071);
            Model.Weight.IsNotValid = Model.Weight.StringVal.IsNullOrEmpty();
            if (Model.Weight.IsNotValid) { SetModelInValid(); }
        }
        private void BloodPressureValidate() {
            Model.BloodPressure.NotValidMessageError = CommonFunction.GetConvertedMessage(Message.MSG_INI_071);
            Model.BloodPressure.IsNotValid = Model.BloodPressure.StringVal.IsNullOrEmpty();
            if (Model.BloodPressure.IsNotValid) { SetModelInValid(); }
        }
        private void GlucouseLevelValidate() {
            Model.GlucouseLevel.NotValidMessageError = CommonFunction.GetConvertedMessage(Message.MSG_INI_071);
            Model.GlucouseLevel.IsNotValid = Model.GlucouseLevel.StringVal.IsNullOrEmpty();
            if (Model.GlucouseLevel.IsNotValid) { SetModelInValid(); }
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

        private async Task NavigateToSignature() {
            NavigationParameters navigationParameters = new NavigationParameters();
            navigationParameters.Add(AppConstant.NavigationParameterName.PAGE, AppConstant.Parameter.MOTHER);
            navigationParameters.Add(AppConstant.NavigationParameterName.DATA, Model);
            await NavigationService.NavigateAsync(AppConstant.Screen.SIGNATURE_PAGE, navigationParameters);
        }
        #endregion


        #endregion
    }

}

