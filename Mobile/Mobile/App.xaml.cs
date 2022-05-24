
#region Modification Log
/*------------------------------------------------------------------------------------------------------------------------------------------------- 
   System      -   Mom & Baby
   Client      -   Cardiff Metropolitan University           
   Module      -   Common
   Sub_Module  -   

   Copyright   -  Cardiff Metropolitan University 

Modification History:
==================================================================================================================================================
Date              Version      		Modify by              					Description
--------------------------------------------------------------------------------------------------------------------------------------------------
20/02/2022        	  1.0         Anuruddha.Rajapaksha   					Initial Version
--------------------------------------------------------------------------------------------------------------------------------------------------*/
#endregion

#region Namespace
using Acr.UserDialogs;
using Mobile.Bluetooth;
using Mobile.Core.RequestProvider;
using Mobile.Data;
using Mobile.Data.BabyAppoinmentData;
using Mobile.Data.MotherAppoinmentData;
using Mobile.Helpers;
using Mobile.Language;
using Mobile.Services;
using Mobile.Services.BabyAppoinmentService;
using Mobile.Services.MotherAppoinmentService;
using Mobile.ViewModels;
using Mobile.Views;
using Mobile.Views.Base;
using PdfSharpCore.Fonts;
using Prism;
using Prism.Events;
using Prism.Ioc;
using Prism.Plugin.Popups;
using Prism.Unity;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
#endregion


[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Mobile {
    public partial class App : PrismApplication {

        private static LocalDatabase database;

        public static double ScreenHeight;
        public static double ScreenWidth;


        /* 
         * The Xamarin Forms XAML Previewer in Visual Studio uses System.Activator.CreateInstance.
         * This imposes a limitation in which the App class must have a default constructor. 
         * App(IPlatformInitializer initializer = null) cannot be handled by the Activator.
         */
        public App() : this(null) {
        }

        public App(IPlatformInitializer initializer) : base(initializer) {
            var ci = DependencyService.Get<ILocalize>().GetCurrentCultureInfo(GlobalSetting.Instance.NetLanguage);
            L10n.SetLocale(ci);
            AppResources.Culture = ci;

            InitAutoMapper.Initialize();
        }


        protected override async void OnInitialized() {
            InitializeComponent();
            await NavigationService.NavigateAsync("app:///TransitionNavigationPage/LoginPage");
        }

        public static LocalDatabase Database {
            get {
                if (database == null) {
                    database = new LocalDatabase(DependencyService.Get<IFileHelper>().GetLocalDbPath());
                }
                return database;
            }
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry) {

            #region View
            // Common Pages
            containerRegistry.RegisterPopupNavigationService();
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<TransitionNavigationPage>();
            containerRegistry.RegisterForNavigation<HomePage>();
            containerRegistry.RegisterForNavigation<LoginPage>();
            containerRegistry.RegisterForNavigation<SettingPage>();
            containerRegistry.RegisterForNavigation<UserMessagePage>();
            containerRegistry.RegisterForNavigation<DiscrepancyPage>();
            containerRegistry.RegisterForNavigation<SynchronizationPage>();
            containerRegistry.RegisterForNavigation<ToolBarItemsPage>();
            containerRegistry.RegisterForNavigation<CalendarPage>();
            containerRegistry.RegisterForNavigation<DateTimeSelectionPage>();
            containerRegistry.RegisterForNavigation<DropDownPage>();
            
            //Settings
            containerRegistry.RegisterForNavigation<LanguageListPage>();
            containerRegistry.RegisterForNavigation<AboutPage>();
            containerRegistry.RegisterForNavigation<LocalDBPage>();

            containerRegistry.RegisterForNavigation<SignaturePage>();

            containerRegistry.RegisterForNavigation<MotherListPage, MotherListPageViewModel>();
            containerRegistry.RegisterForNavigation<BabyListPage, BabyListPageViewModel>();
            containerRegistry.RegisterForNavigation<BabyAppointmentPage, BabyAppointmentPageViewModel>();
            containerRegistry.RegisterForNavigation<MotherAppointmentPage, MotherAppointmentPageViewModel>();
            containerRegistry.RegisterForNavigation<BabyPage, BabyPageViewModel>();
            containerRegistry.RegisterForNavigation<BabyAppointmentListPage, BabyAppointmentListPageViewModel>();
            containerRegistry.RegisterForNavigation<MotherPage, MotherPageViewModel>();
            containerRegistry.RegisterForNavigation<MotherAppointmentListPage, MotherAppointmentListPageViewModel>();
            
            
            containerRegistry.RegisterForNavigation<ArrivalTimeSelectPage, ArrivalTimeSelectPageViewModel>();
            #endregion

            #region Api
            if (!Settings.UseMock) {
                containerRegistry.RegisterSingleton<IRequestProvider, RequestProvider>();
                containerRegistry.RegisterSingleton<ILoginService, LoginService>();
                containerRegistry.RegisterSingleton<IUserSettingService, UserSettingService>();
                containerRegistry.RegisterSingleton<IMotherService, MotherService>();
                containerRegistry.RegisterSingleton<IMotherAppoinmentService, MotherAppoinmentService>();
                containerRegistry.RegisterSingleton<IBabyService, BabyService>();
                containerRegistry.RegisterSingleton<IBabyAppoinmentDataService, BabyAppoinmentDataService>();
            } else {
                containerRegistry.RegisterSingleton<IRequestProvider, RequestProvider>();
                containerRegistry.RegisterSingleton<ILoginService, MockLoginService>();
                containerRegistry.RegisterSingleton<IUserSettingService, MockUserSettingService>();
                containerRegistry.RegisterSingleton<IMotherService, MockMotherService>();
                containerRegistry.RegisterSingleton<IMotherAppoinmentService, MockMotherAppoinmentService>();
                containerRegistry.RegisterSingleton<IBabyService, MockBabyService>();
                containerRegistry.RegisterSingleton<IBabyAppoinmentService, MockBabyAppoinmentService>();
            }
            #endregion

            #region Local Database Service
            if (!Settings.UseMock) {
                containerRegistry.RegisterSingleton<IMidwifeDataService, MidwifeDataService>();
                containerRegistry.RegisterSingleton<IUserFunctionDataService, UserFunctionDataService>();
                containerRegistry.RegisterSingleton<IUserSettingDataService, UserSettingDataService>();
                containerRegistry.RegisterSingleton<IMotherDataService, MotherDataService>();
                containerRegistry.RegisterSingleton<IMotherAppoinmentDataService, MotherAppoinmentDataService>();
                containerRegistry.RegisterSingleton<IBabyDataService, BabyDataService>();
                containerRegistry.RegisterSingleton<IBabyAppoinmentDataService, BabyAppoinmentDataService>();
            } else {
                containerRegistry.RegisterSingleton<IMidwifeDataService, MockMidwifeDataService>();
                containerRegistry.RegisterSingleton<IUserFunctionDataService, MockUserFunctionDataService>();
                containerRegistry.RegisterSingleton<IUserSettingDataService, MockUserSettingDataService>();
                containerRegistry.RegisterSingleton<IMotherDataService, MockMotherDataService>();
                containerRegistry.RegisterSingleton<IMotherAppoinmentDataService, MockMotherAppoinmentDataService>();
                containerRegistry.RegisterSingleton<IBabyDataService, MockBabyDataService>();
                containerRegistry.RegisterSingleton<IBabyAppoinmentDataService, MockBabyAppoinmentDataService>();
            }
            #endregion

            #region Platform Specific
            containerRegistry.RegisterInstance<IUserDialogs>(UserDialogs.Instance);
            var bluetoothScanner = DependencyService.Get<IBluetoothDevice>();
            containerRegistry.RegisterInstance<IBluetoothDevice>(bluetoothScanner);

            var loaderService = DependencyService.Get<ILoadingPageService>();
            loaderService.InitLoadingPage();
            containerRegistry.RegisterInstance<ILoadingPageService>(loaderService);
            #endregion

            #region Helper and ModuleLogic
            if (!Settings.UseMock) {
                containerRegistry.RegisterSingleton<ICommonFunction, CommonFunction>();
            } else {
                containerRegistry.RegisterSingleton<ICommonFunction, CommonFunction>();
            }

            var EventAggregator = this.Container.Resolve<IEventAggregator>();
            GlobalSetting.Instance.EventAggregator = EventAggregator;
            #endregion


        }
        
    }
}
