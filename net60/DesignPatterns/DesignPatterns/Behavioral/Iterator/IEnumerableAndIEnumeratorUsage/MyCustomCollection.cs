using System.Collections;
using System.Linq;
using System.Collections.Generic;

namespace DesignPatterns.Behavioral.Iterator.IEnumerableAndIEnumeratorUsage
{
    public class MyCustomCollection : IEnumerable<int>
    {
        private List<int> _myPrivateList;        

        public MyCustomCollection()
        {
            _myPrivateList = Enumerable.Range(1,10).ToList();
        }

        public IEnumerator GetEnumerator()
        {
            return new MyCustomListIntEnumerator(_myPrivateList);
        }

        IEnumerator<int> IEnumerable<int>.GetEnumerator()
        {
            return new MyCustomListIntEnumerator(_myPrivateList);
        }
    }
}

