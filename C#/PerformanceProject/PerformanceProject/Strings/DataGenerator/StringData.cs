using System;
using System.Collections.Generic;
using System.Linq;

namespace PerformanceProject.Strings.DataGenerator
{
    public class StringData
    {
        private static Random random = new Random();
        private IEnumerable<string> _data;
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";

        public StringData(int numberOfStrings = 5000)
        {
            if (numberOfStrings < 5000)
                throw new ArgumentNullException("Not supported");

            this._data = Enumerable.Repeat(chars, numberOfStrings).Select(s => s.Substring(random.Next(s.Length)));
        }

        public IEnumerable<string> GetData()
        {
            return _data;
        }
    }
}
