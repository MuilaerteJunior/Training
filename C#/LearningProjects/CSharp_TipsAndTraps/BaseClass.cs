using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_TipsAndTraps {
    public class BaseClass {
        public string Name { get; set; }
        private int _length;

        /// <summary>
        /// You must avoid calling virtual methods from constructor!!!
        /// </summary>
        public BaseClass() {
            InitName();

            _length = Name.Length;
        }

        protected  virtual void InitName() {
            Name = "Muilaerte";
        }
    }

}
