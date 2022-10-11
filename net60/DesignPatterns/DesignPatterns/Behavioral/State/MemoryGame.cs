using System;
using System.Collections.Generic;
using System.Linq;

namespace DesignPatterns.Behavioral.State
{
    public class MemoryGame 
    {
        public GameState MyState { get; internal set;}
        protected int[] MyBoard  { get; set; }

        private Random rand = new Random();

        public MemoryGame() 
        {            
            InitialState();
        }

        private void InitialState(){
            MyState = new StoppedState(this);
            MyBoard = GenerateCards(6).ToArray();
        }

        public IEnumerable<int> GenerateCards(short numberOfPairs){            
            var cardsPosition = new int?[numberOfPairs*2];
            bool pairDistribution = false;
            for ( var index  = 0; index < numberOfPairs; index++){
                var myPosition = rand.Next(cardsPosition.Length);
                if ( cardsPosition[myPosition] == null){
                    cardsPosition[myPosition] = index;
                    
                    if ( !pairDistribution ){
                        index--;
                        pairDistribution = true;
                    } else 
                        pairDistribution = false;
                } else
                    index--;
            }
            return cardsPosition.Select(a => a.Value);
        }
        
        public void Pause()
        {
            MyState.Pause();
        }

        public void Resume()
        {
            MyState.Resume();
        }

        public void Start()
        {       
            MyState.Start();
        }

        public void Stop()
        {
            MyState.Stop();
        }
    }
}
