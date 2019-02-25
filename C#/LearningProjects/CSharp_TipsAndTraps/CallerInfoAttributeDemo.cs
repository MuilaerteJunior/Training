using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_TipsAndTraps {
    class CallerInfoAttributeDemo {

        public string WhoCalledMe([CallerMemberName] string callingMember = null) {
            return "I was a called member " + callingMember;
        }

        
        public string WhatFilledCAlledMe([CallerFilePath] string callerFilePath = null) {
            return "I was a called from a file " + callerFilePath;
        }

        
        public string WhatLineCalledMe([CallerLineNumber] int callingLineNum = 0) {
            return "I was a called member" + callingLineNum;
        }
    }

    internal class CallerInfoAttributeDemo2 : INotifyPropertyChanged {
        private string _name;

        public string Name {

            get {
                return _name;
            }
            set {
                _name = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null) {
            if (PropertyChanged != null ) {
                var eventArgs = new PropertyChangedEventArgs(propertyName);
                PropertyChanged(this, eventArgs);
            }
        }
    }
}
