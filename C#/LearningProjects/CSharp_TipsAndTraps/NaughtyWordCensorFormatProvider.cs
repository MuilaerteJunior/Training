using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_TipsAndTraps {
    public class NaughtyWordCensorFormatProvider : IFormatProvider, ICustomFormatter {
        public string Format(string format, object arg, IFormatProvider formatProvider) {
            if (format == "xxx" ) {
                return CensorNaughtyWord(arg.ToString());
            }

            return arg.ToString();

        }

        private string CensorNaughtyWord(string v) {

            return v.Replace("fdp", "f*p");

        }

        public object GetFormat(Type formatType) {
            if ( formatType == typeof(ICustomFormatter) ) {
                return this;
            }

            return null;
        }
    }
}
