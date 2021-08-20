using System.Linq;
using System.Collections.Generic;

//TODO: Create an example using IEnumerable also!  https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/iterators
namespace DesignPatterns.Behavioral.Iterator
{
    public class MyRandomCollection : ICustomIterator<int>
    {
        private List<int> _myInternalList;
        private int _currentIndex = 0;

        public MyRandomCollection(){
            _myInternalList = Enumerable.Range(1,10).ToList();
        }

        public bool HasNext()
        {
            return ( _currentIndex <  _myInternalList.Count);
        }

        public int Next()
        {
            return _myInternalList[_currentIndex++];
        }
    }
}

