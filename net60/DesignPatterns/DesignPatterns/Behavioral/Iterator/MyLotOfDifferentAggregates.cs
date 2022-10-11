using System.Collections.Generic;
using DesignPatterns.Behavioral.Iterator;

namespace DesignPatterns.Behavioral.Iterator
{
    public class MyLotOfDifferentAggregates     
    {
        private IList<ICustomIterator<int>> _myDifferentAggregates;

        public MyLotOfDifferentAggregates(MyRandomMatrix a , MyRandomCollection b){
            _myDifferentAggregates.Add(a);
            _myDifferentAggregates.Add(b);
        }
        public MyLotOfDifferentAggregates()
        {
            _myDifferentAggregates = new List<ICustomIterator<int>>();
        }

        public void AddMyGuys(ICustomIterator<int> customIteratorGuy){
            _myDifferentAggregates.Add(customIteratorGuy);
        }
        
        public IList<string> RunOverMyAggregates(){
            var r = new List<string>();
            foreach (var i in _myDifferentAggregates){
                while ( i.HasNext() )
                {
                    var currentItem = i.Next();
                    r.Add(currentItem.ToString());
                }
            }

            return r;
        }
    }
}

