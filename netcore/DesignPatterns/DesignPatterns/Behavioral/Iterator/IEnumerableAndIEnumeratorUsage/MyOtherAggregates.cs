using System;
using System.Collections.Generic;

namespace DesignPatterns.Behavioral.Iterator.IEnumerableAndIEnumeratorUsage
{
    public class MyOtherAggregates{
        private MyArrayCollection _myItemA;
        private MyCustomCollection _myItemB;

        public MyOtherAggregates(MyArrayCollection a, MyCustomCollection b)
        {
            _myItemA = a;
            _myItemB = b;
        }

        public IList<string> LetsRunOverAggregates()
        {
            var r = new List<String>();
            foreach (int item in _myItemA){
                r.Add(item.ToString());
            }
            foreach (int item in _myItemB){
                r.Add(item.ToString());
            }
            return r;
        }
    }
}

