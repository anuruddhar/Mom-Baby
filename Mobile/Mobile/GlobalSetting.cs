
#region Modification Log
/*------------------------------------------------------------------------------------------------------------------------------------------------- 
   System      -   Mom & Baby
   Client      -   Cardiff Metropolitan University           
   Module      -   Mobile
   Sub_Module  -   

   Copyright   -  Cardiff Metropolitan University 

Modification History:
==================================================================================================================================================
Date              Version      Modify by              Description
--------------------------------------------------------------------------------------------------------------------------------------------------
20/02/2022        1.0          Anuruddha.Rajapaksha   	 Initial Version
--------------------------------------------------------------------------------------------------------------------------------------------------*/
#endregion

#region Namespace
using Mobile.Data;
using Mobile.Enum;
using Mobile.Helpers;
using Mobile.Models.Login;
using Prism.Events;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.IO;
#endregion

namespace Mobile {
    public class GlobalSetting {

        #region Private Variables
        private object _context;
        private string _server;
        private string _dbName;
        private static readonly GlobalSetting _instance = new GlobalSetting(new DependencyService());
        private LocalDatabase _database;
        private int _pageSize;
        private string _netLanguage;
        private Midwife _user = new Midwife();
        private IEventAggregator eventAggregator;

        private const string _serverName = AppConstant.ServerName.DEV;
        #endregion

        #region Properties
        public object Context {
            get { return _context; }
            set { _context = value; }
        }


        public readonly static string EndPoint = $"https://mombaby.i3xhosting.com";


        public static TransitionType TransitionType = TransitionType.Flip;

        public string AuthToken { get; internal set; }

        public static GlobalSetting Instance {
            get { return _instance; }
        }

        public string Server {
            get { return _server; }
            set { _server = value; }
        }

        public int PageSize {
            get { return _pageSize; }
            set { _pageSize = value; }
        }

        public string DbName {
            get { return _dbName; }
            set { _dbName = value; }
        }

        public string NetLanguage {
            get { return _netLanguage; }
            set { _netLanguage = value; }
        }

        public LocalDatabase Database {
            get { return _database; }
            set { _database = value; }
        }

        public IEventAggregator EventAggregator {
            get {
                return eventAggregator;
            }
            set {
                eventAggregator = value;
            }
        }

        public string PDTNo { get; set; } = "PDTN01";


        public string NoAnalysisRemarkConvertedText { get; set; }

        public Midwife User {
            get {
                return _user;
            }
            set {
                _user = value;
                AuthToken = value.Token;
            }
        }

        public bool IsPopupOpened { get; set; } = false; // This is to prevent the back button press behaviour
        public bool IsToolbarOpened { get; set; } = false; // This is to prevent multiple time toolbar opened behaviour
        public bool IsNavigationStarted { get; set; } = false; // This is to prevent multiple time same page opened behaviour
        #endregion

        #region Constructor
        public GlobalSetting(IDependencyService dependencyService) {
            AuthToken = "INSERT AUTHENTICATION TOKEN";
            Server = _serverName;
            _pageSize = 20;
            _netLanguage = (string.IsNullOrEmpty(Settings.Language)) ? "en" : Settings.Language;
            _dbName = "Database.db3";
        }
        #endregion

        #region Methods
        #endregion
    }
}
