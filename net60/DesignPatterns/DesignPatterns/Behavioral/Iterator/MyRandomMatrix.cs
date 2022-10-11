using System.Linq;

//TODO: Create an example using IEnumerable also!  https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/iterators
namespace DesignPatterns.Behavioral.Iterator
{
    public class MyRandomMatrix : ICustomIterator<int>
    {
        private int[][] _myInternalMatrix;
        
        //Order left to right, up to bottom
        private int _currentIndexX = 0, _currentIndexY = 0;

        public MyRandomMatrix()
        {
            _myInternalMatrix = Enumerable
                        .Range(1,10)
                        .Select(c => Enumerable.Repeat(c * 10, 6).ToArray())
                        .ToArray();
        }

        public bool HasNext()
        {
            //0,0 0,1 0,2
            //1,0 1,1 1,2
            //2,0 2,1 2,2
            //3,0 3,1 3,2
            //_myInternalMatrix[_currentIndexX].Length = 4
            //_myInternalMatrix[_currentIndexY].Length = 3
            //current_index_x = 0
            //current_index_y = 3
            return ( _currentIndexX < _myInternalMatrix[_currentIndexX].Length) && (_currentIndexY < _myInternalMatrix[_currentIndexY].Length );
        }

        public int Next()
        {
            var next = _myInternalMatrix[_currentIndexX++][_currentIndexY];            
            if ( _currentIndexX >= _myInternalMatrix[_currentIndexX].Length){
                _currentIndexX = 0;
                _currentIndexY++;
            }
            return next;
        }
    }
}

