using System.Collections;
using System;
using System.Collections.Generic;

namespace DesignPatterns.Behavioral.Iterator.IEnumerableAndIEnumeratorUsage
{
    public class MyCustomArrayIntEnumerator : IEnumerator<int>
    {
        private int _currentIndex;
        private int _currentElement;
        private int[] _myPrivateArray;

        public int Current{
            get {
                if (_currentIndex >= 0 && _currentIndex < _myPrivateArray.Length)
                    return _currentElement;
                
                throw new InvalidOperationException();
            }
        }

        object IEnumerator.Current {
            get {
                if (_currentIndex >= 0 && _currentIndex < _myPrivateArray.Length)
                    return _currentElement;
                
                throw new InvalidOperationException();
            }
        }

        public MyCustomArrayIntEnumerator(int[] collection)
        {
            _myPrivateArray = collection;
            _currentIndex =  -1;
        }

        public void Dispose()
        {
            if ( _myPrivateArray != null)
                _myPrivateArray = null;
        }

        public bool MoveNext()
        {
            if ( _currentIndex < (_myPrivateArray.Length-1)){
                _currentIndex++;
                _currentElement = _myPrivateArray[_currentIndex];
                return true;
            } else
                _currentIndex =  _myPrivateArray.Length;
            return false;
        }

        public void Reset()
        {
            _currentIndex = -1; 
            _currentElement = 0;
        }
    }
}

