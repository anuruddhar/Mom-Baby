#region Modification Log
/*------------------------------------------------------------------------------------------------------------------------------------------------- 
   System      -   GTS
   Client      -   AirLiquide Industrial Services (Private)Limited           
   Module      -   Delivery
   Sub_Module  -   

   Copyright   -   AirLiquide Industrial Services (Private)Limited  

Modification History:
==================================================================================================================================================
Date              Version      		Modify by              					Description
--------------------------------------------------------------------------------------------------------------------------------------------------
30/07/2018         	  1.0         Anuruddha.Rajapaksha   					Initial Version
03/02/2020            1.1         Anuruddha.Rajapaksha                      29179 - GTS Mobile - Signature label to change "Please Sign above the line"
                                                                            29175 - GTS Mobile - If clear the signature, reset the customer satisfaction selection and enforce to select once again survey rate
--------------------------------------------------------------------------------------------------------------------------------------------------*/
#endregion

#region Namespace
using Acr.UserDialogs;
using Mobile.Core.Helpers;
using Mobile.Data.BabyAppoinmentData;
using Mobile.Data.MotherAppoinmentData;
using Mobile.Enum;
using Mobile.FormModel;
using Mobile.Helpers;
using Mobile.Models;
using Mobile.Models.Baby;
using Mobile.Models.Mother;
using Mobile.Services.BabyAppoinmentService;
using Mobile.Services.MotherAppoinmentService;
using Prism.Commands;
using Prism.Events;
using Prism.Navigation;
using SignaturePad.Forms;
using System;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
#endregion

namespace Mobile.ViewModels {
    public class SignaturePageViewModel : ViewModelBase {

        #region Private Variables
        #region UI
        private string _skipIcon = AppConstant.AppIcons.ICO_COM_SKIP_RATING;
        private string _smileIcon = AppConstant.AppIcons.ICO_COM_SMILEY_FACE;
        private string _neutralIcon = AppConstant.AppIcons.ICO_COM_NEUTRAL_FACE;
        private string _sadIcon = AppConstant.AppIcons.ICO_COM_SAD_FACE;
        private string _printIcon = AppConstant.AppIcons.ICO_COM_PRINT;
        private string _saveIcon = AppConstant.AppIcons.ICO_COM_ADD_SAVE;
        #endregion

        private IMotherAppoinmentDataService _motherAppoinmentDataService;
        private IMotherAppoinmentService _motherAppoinmentService;
        private IBabyAppoinmentDataService _babyAppoinmentDataService;
        private IBabyAppoinmentService _babyAppoinmentService;

        private string _signerName = string.Empty;
        private bool _isRated = false;
        private bool _isSigned = false;
        private ImageSource _imageSource;
        private AppointmentBase _appointmentBase = new AppointmentBase();
        private string _page = string.Empty;


        public MotherAppoinmentFormModel MotherModel { get; set; }
        public BabyAppoinmentFormModel BabyModel { get; set; }
        #endregion

        #region Properties
        #region UI
        public string SkipIcon {
            get { return _skipIcon; }
            set { SetProperty(ref _skipIcon, value); }
        }
        public string SmileIcon {
            get { return _smileIcon; }
            set { SetProperty(ref _smileIcon, value); }
        }
        public string NeutralIcon {
            get { return _neutralIcon; }
            set { SetProperty(ref _neutralIcon, value); }
        }
        public string SadIcon {
            get { return _sadIcon; }
            set { SetProperty(ref _sadIcon, value); }
        }
        public string PrintIcon {
            get { return _printIcon; }
            set { SetProperty(ref _printIcon, value); }
        }
        public string SaveIcon {
            get { return _saveIcon; }
            set { SetProperty(ref _saveIcon, value); }
        }

        public ImageSource Signature {
            get { return _imageSource; }
            set { SetProperty(ref _imageSource, value); }
        }
        #endregion



        public string SignerName {
            get { return _signerName; }
            set { SetProperty(ref _signerName, value); }
        }
        public bool IsRated {
            get { return _isRated; }
            set { SetProperty(ref _isRated, value); }
        }
        public bool IsSigned {
            get { return _isSigned; }
            set { SetProperty(ref _isSigned, value); }
        }

        public ICommand SkipCommand { get; set; }
        public ICommand SmileCommand { get; set; }
        public ICommand NeutralCommand { get; set; }
        public ICommand SadCommand { get; set; }
        public ICommand SaveCommand { get; set; }
        public ICommand StrokeCompletedCommand { get; set; }
        public ICommand SignatureClearedCommand { get; set; }
        public Func<SignatureImageFormat, ImageConstructionSettings, Task<Stream>> GetImageStreamAsync { get; set; }

        #endregion

        #region Constructor
        public SignaturePageViewModel(INavigationService navigationService,
                                      IEventAggregator eventAggregator,
                                      IUserDialogs dialogs,
                                      ICommonFunction commonFunction,
                                      IBabyAppoinmentDataService babyAppoinmentDataService,
                                      IBabyAppoinmentService babyAppoinmentService,
                                      IMotherAppoinmentDataService motherAppoinmentDataService,
                                      IMotherAppoinmentService motherAppoinmentService)
        : base(navigationService, eventAggregator, dialogs, commonFunction, Message.CAP_SIGNATURE) {
            SkipCommand = new DelegateCommand(async () => await OnSkip());
            SmileCommand = new DelegateCommand(async () => await OnSmile());
            NeutralCommand = new DelegateCommand(async () => await OnNeutral());
            SadCommand = new DelegateCommand(async () => await OnSad());
            SaveCommand = new DelegateCommand(async () => await OnSave());
            StrokeCompletedCommand = new DelegateCommand(OnSign);
            SignatureClearedCommand = new DelegateCommand(OnSignRemoved);

            _babyAppoinmentDataService = babyAppoinmentDataService;
            _babyAppoinmentService = babyAppoinmentService;
            _motherAppoinmentDataService = motherAppoinmentDataService;
            _motherAppoinmentService = motherAppoinmentService;
        }
        #endregion

        #region Methods

        #region Lifecycle hooks & Related Methods
        protected override async Task OnInitializeAsync(INavigationParameters parameters) {
            try {
                _page = (string)parameters[AppConstant.NavigationParameterName.PAGE];
                if (_page == AppConstant.Parameter.MOTHER) {
                    MotherModel = (MotherAppoinmentFormModel)parameters[AppConstant.NavigationParameterName.DATA];
                } else {
                    BabyModel = (BabyAppoinmentFormModel)parameters[AppConstant.NavigationParameterName.DATA];
                }
                ShowActivityIndicator(Message.CAP_LOADING);
                AddModuleSpecificCustomToolBars();
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
                }
            } catch (Exception ex) {
                await ShowErrorMessage(true, ex);
            }
        }

        private async Task InvokeCallBack(INavigationParameters parameters) {
            _callBackFunctionCode = (string)parameters[AppConstant.NavigationParameterName.CALL_BACK_FUNCTION_CODE];
            switch (_callBackFunctionCode) {
                case AppConstant.NavigationParameterName.CALL_BACK_SAVE:
                    //await NavigationService.GoBackAsync();
                    await NavigationService.NavigateAsync("../../");
                    break;
                case AppConstant.NavigationParameterName.CALL_BACK_DATA_SYNC_SUCESS: // Notification send
                    await CallbackNotificationSend();
                    break;
                default:
                    break;
            }
        }
        #endregion

        #region CallBack
        private async Task CallbackNotificationSend() {
            await SaveAppoinment();
        }
        #endregion

        #region Event Handlers
        private async Task OnSkip() {
            try {
                _appointmentBase.SatisfactionId = Satisfaction.Skip;
                IsRated = true;
            } catch (Exception ex) {
                await ShowErrorMessage(true, ex);
            }
        }

        private async Task OnSmile() {
            try {
                _appointmentBase.SatisfactionId = Satisfaction.High;
                IsRated = true;
            } catch (Exception ex) {
                await ShowErrorMessage(true, ex);
            }
        }

        private async Task OnNeutral() {
            try {
                _appointmentBase.SatisfactionId = Satisfaction.Medium;
                IsRated = true;
            } catch (Exception ex) {
                await ShowErrorMessage(true, ex);
            }
        }
        private async Task OnSad() {
            try {
                _appointmentBase.SatisfactionId = Satisfaction.Low;
                IsRated = true;
            } catch (Exception ex) {
                await ShowErrorMessage(true, ex);
            }
        }

        private void OnSign() {
            IsSigned = true;
        }

        private void OnSignRemoved() {
            IsSigned = false;
            IsRated = false;
        }


        private async Task OnSave() {
            try {
                //  await SendDeliveryNotification(3, 0);
                await SaveAppoinment();
            } catch (Exception ex) {
                await ShowErrorMessage(true, ex);
            }
        }
        #endregion

        #region Save
        private async Task<bool> SaveAppoinment() {
            try {
                if (!IsSigned || string.IsNullOrEmpty(SignerName.Trim())) {
                    await DisplayMessage(MessageType.Validation, Message.CAP_SIGNATURE, Message.MSG_DEL_041);
                    return false;
                }
                ShowActivityIndicator(Message.CAP_SAVING);
                await SaveSignatureImage();
                _appointmentBase.SignerName = SignerName.Trim();

                await ConnectionDecider.Instance.DoProcessing(2, this);

                HideActivityIndicator();
                return true;
            } catch (Exception ex) {
                await this.ShowErrorMessage(true, ex);
                return false;
            }
        }

        private async Task<bool> SaveSignatureImage() {
            try {
                var settings = new ImageConstructionSettings {
                    StrokeColor = Color.Black,
                    BackgroundColor = Color.White,
                    StrokeWidth = 3f
                };

                using (var bitmap = await GetImageStreamAsync(SignatureImageFormat.Png, settings)) {
                    // 1. Save to File
                    await DependencyService.Get<IFileHelper>().SaveSignature(_appointmentBase.PrimaryId.ToString(), bitmap);

                    // 2. Save to Object
                    _appointmentBase.Signature = StreamHelper.StreamToByteArray(bitmap);
                }
                return true;
            } catch (Exception ex) {
                await DisplayMessage(MessageType.Error, Message.CAP_SIGNATURE, Message.ERR_UN_EXPECTED);
                await this.ShowErrorMessage(false, ex);
                return false;
            }
        }


        private async Task<bool> SaveBabyAppoinmentOnline() {
            try {
                var data = InitAutoMapper.Initialize().Map<BabyAppoinment>(BabyModel);
                data.SignerName = _appointmentBase.SignerName;
                data.Signature = _appointmentBase.Signature;
                await _babyAppoinmentService.InsertItemAsyn(data);
                object[] messageValue = new object[] { string.Empty };
                await DisplayMessage(MessageType.Sucesss, Message.CAP_SAVE, Message.MSG_SAVE, messageValue, false, AppConstant.NavigationParameterName.CALL_BACK_SAVE);
                return true;
            } catch (Exception ex) {
                throw ex;
            }
        }
        private async Task<bool> SaveBabyAppoinmentOffline() {
            try {
                var data = InitAutoMapper.Initialize().Map<BabyAppoinment>(BabyModel);
                data.SignerName = _appointmentBase.SignerName;
                data.Signature = _appointmentBase.Signature;
                await _babyAppoinmentDataService.InsertItemAsyn(data);
                object[] messageValue = new object[] { string.Empty };
                await DisplayMessage(MessageType.Warning, Message.CAP_SAVE, Message.MSG_SAVE_LOCALLY, messageValue, false, AppConstant.NavigationParameterName.CALL_BACK_SAVE);
                return true;
            } catch (Exception ex) {
                throw ex;
            }
        }

        protected async Task<bool> SaveMotherAppoinmentOnline() {
            try {
                var data = InitAutoMapper.Initialize().Map<MotherAppoinment>(MotherModel);
                data.SignerName = _appointmentBase.SignerName;
                data.Signature = _appointmentBase.Signature;
                await _motherAppoinmentService.InsertItemAsyn(data);
                object[] messageValue = new object[] { string.Empty };
                await DisplayMessage(MessageType.Sucesss, Message.CAP_SAVE, Message.MSG_SAVE, messageValue, false, AppConstant.NavigationParameterName.CALL_BACK_SAVE);
                return true;
            } catch (Exception ex) {
                throw ex;
            }
        }
        protected async Task<bool> SaveMotherAppoinmentOffline() {
            try {
                var data = InitAutoMapper.Initialize().Map<MotherAppoinment>(MotherModel);
                data.SignerName = _appointmentBase.SignerName;
                data.Signature = _appointmentBase.Signature;
                await _motherAppoinmentDataService.InsertItemAsyn(data);
                object[] messageValue = new object[] { string.Empty };
                await DisplayMessage(MessageType.Warning, Message.CAP_SAVE, Message.MSG_SAVE_LOCALLY, messageValue, false, AppConstant.NavigationParameterName.CALL_BACK_SAVE);
                return true;
            } catch (Exception ex) {
                throw ex;
            }
        }

        #endregion

        #region IConnectionDecider Members
        protected async override Task<bool> OnDoOnlineProcessing() {
            try {
                if (_page == AppConstant.Parameter.MOTHER) {
                    await SaveMotherAppoinmentOnline();
                } else {
                    await SaveBabyAppoinmentOnline();
                }
                return true;
            } catch (Exception ex) {
                await ShowErrorMessage(true, ex);
                throw ex;
            }
        }
        protected async override Task<bool> OnDoOfflineProcessing() {
            try {
                if (_page == AppConstant.Parameter.MOTHER) {
                    await SaveMotherAppoinmentOffline();
                } else {
                    await SaveBabyAppoinmentOffline();
                }
                return true;
            } catch (Exception ex) {
                await ShowErrorMessage(true, ex);
                throw ex;
            }
        }
        #endregion


        #endregion
    }
}
