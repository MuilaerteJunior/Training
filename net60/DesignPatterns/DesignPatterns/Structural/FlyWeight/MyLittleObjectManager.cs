namespace DesignPatterns.Structural.FlyWeight
{
    public class MyLittleObjectManager
    {
        private MyLittleObject[] _myObjects;
        private const short _listSize = 10;
        private short _currentIndex = 0;

        public MyLittleObjectManager()
        {
            _myObjects = new MyLittleObject[_listSize];
        }

        public void AddMyObject(MyLittleObject littleObject)
        {
            if (_currentIndex < _listSize)
                _myObjects[_currentIndex++] = littleObject;
        }

        public MyLittleObject GetMyObject(int position)
        {
            if (position >= 0 && position < _myObjects.Length)
                return _myObjects[position];

            return null;
        }
    }

}
