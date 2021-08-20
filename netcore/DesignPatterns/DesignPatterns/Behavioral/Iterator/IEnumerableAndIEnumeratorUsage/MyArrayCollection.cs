using System.Collections;
using System.Linq;
using System.Collections.Generic;

namespace DesignPatterns.Behavioral.Iterator.IEnumerableAndIEnumeratorUsage
{
    public class MyArrayCollection : IEnumerable<int>
    {
        private int[] _myPrivateArray;
        public MyArrayCollection()
        {
            _myPrivateArray = Enumerable.Range(11,10).ToArray();
        }

        public IEnumerator<int> GetEnumerator()
        {
            return new MyCustomArrayIntEnumerator(_myPrivateArray);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return new MyCustomArrayIntEnumerator(_myPrivateArray);
        }
    }
}

