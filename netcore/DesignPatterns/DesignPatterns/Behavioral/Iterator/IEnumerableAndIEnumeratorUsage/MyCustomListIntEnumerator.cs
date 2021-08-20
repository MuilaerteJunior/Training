using System.Collections;
using System;
using System.Collections.Generic;

namespace DesignPatterns.Behavioral.Iterator.IEnumerableAndIEnumeratorUsage
{
    public class MyCustomListIntEnumerator : IEnumerator<int>
    {
        private int _currentIndex;
        private int _currentElement;
        private IList<int> _myPrivateList;

        public int Current{
            get {
                if (_currentIndex >= 0 && _currentIndex < _myPrivateList.Count)
                    return _currentElement;
                
                throw new InvalidOperationException();
            }
        }

        object IEnumerator.Current {
            get {
                if (_currentIndex >= 0 && _currentIndex < _myPrivateList.Count)
                    return _currentElement;
                
                throw new InvalidOperationException();
            }
        }

        public MyCustomListIntEnumerator(IList<int> collection)
        {
            _myPrivateList = collection;
            _currentIndex =  -1;
        }

        public void Dispose()
        {
            if ( _myPrivateList != null)
                _myPrivateList = null;
        }

        public bool MoveNext()
        {
            if ( _currentIndex < (_myPrivateList.Count-1)){
                _currentIndex++;
                _currentElement = _myPrivateList[_currentIndex];
                return true;
            } else
                _currentIndex =  _myPrivateList.Count;
            return false;
        }

        public void Reset()
        {
            _currentIndex =  -1;
            _currentElement = 0;
        }
    }
}

