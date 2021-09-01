namespace DesignPatterns.Behavioral.State
{    
    public abstract class GameState
    {
        public MemoryGame MyContext { get; protected set; }
        
        public GameState(MemoryGame t){
            this.MyContext = t;
        
        }
        public abstract void Start();
        public abstract void Pause();
        public abstract void Stop();
        public abstract void Resume();
    }
}
