using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_TipsAndTraps
{
    [DebuggerDisplay("This Person is called: {Name}.")]
    public class PersonWithDebuggerDisplay {
        private string _name;
        private string _gender;
        private int __age;

        public PersonWithDebuggerDisplay() { }

        public PersonWithDebuggerDisplay(string name) 
            : this (name, default(int), default(string))
        {
        }
        
        public PersonWithDebuggerDisplay(string name, int age) 
            : this(name, age, default(string)) 
        {
        }
        
        public PersonWithDebuggerDisplay(string name, int age, string gender) 
        {
            this._name = name;
            this._gender = gender;
            this.__age = age;
        }


        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public string Name { get; set; }

        [DebuggerDisplay("Age in years:  {AgeInYears}.")]
        public int AgeInYears { get; set; }

        [DebuggerBrowsable(DebuggerBrowsableState.RootHidden)]
        public List<string> FavoriteColors { get; set; }
    }
}