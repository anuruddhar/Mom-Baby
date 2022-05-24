
#region Modification Log
/*------------------------------------------------------------------------------------------------------------------------------------------------- 
    System      -   Mom & Baby
    Client      -   Cardiff Metropolitan University           
    Module      -   Mobile.Helpers
    Sub_Module  -   

    Copyright   -  Cardiff Metropolitan University 
 
 Modification History:
 ==================================================================================================================================================
 Date              Version      Modify by              Description
 --------------------------------------------------------------------------------------------------------------------------------------------------
 19/02/2020         1.0      Anuruddha.Rajapaksha          Initial Version
--------------------------------------------------------------------------------------------------------------------------------------------------*/
#endregion

#region Namespace
using Mobile.Helpers;
using System.Collections.ObjectModel;
using System.ComponentModel;
#endregion

namespace Mobile.Models.Common {
    public class AppMenuGroup : ObservableCollection<AppMenuItem>, INotifyPropertyChanged {
        public event PropertyChangedEventHandler PropertyChanged;
        private bool _Expanded;
        private string _Title;
        private string _MenuIcon;
        private int _Order;

        public bool Expanded {
            get { return _Expanded; }
            set {
                if (_Expanded != value) {
                    _Expanded = value;
                    OnPropertyChanged("Expanded");
                    OnPropertyChanged("StateIcon");
                }
            }
        }

        public string Title {
            get {
                return _Title;
            }
            set {
                _Title = value;
            }
        }

        public string MenuIcon {
            get {
                return _MenuIcon;
            }
            set {
                _MenuIcon = value;
            }
        }

        public int Order {
            get {
                return _Order;
            }
            set {
                _Order = value;
            }
        }

        public string StateIcon {
            get { return Expanded ? AppConstant.AppIcons.ICO_MNU_COLLAPSEMENU : AppConstant.AppIcons.ICO_MNU_EXPANDMENU; }
        }

        protected virtual void OnPropertyChanged(string propertyName) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public AppMenuGroup(string title, string icon, int order, bool expanded = false) {
            _Title = title;
            _MenuIcon = icon;
            _Order = order;
            Expanded = expanded;
        }
    }
}
