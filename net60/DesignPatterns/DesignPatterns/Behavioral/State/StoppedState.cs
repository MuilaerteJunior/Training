namespace DesignPatterns.Behavioral.State
{
    public class StoppedState : GameState
    {
        public StoppedState(GameState lastState) : base(lastState.MyContext)
        {
            
        }

        public StoppedState(MemoryGame start) : base(start){}

        public override void Pause()
        {
            throw new System.NotImplementedException();
        }

        public override void Resume()
        {
            throw new System.NotImplementedException();
        }

        public override void Start()
        {
            this.MyContext.MyState = new StartedState(this);            
        }

        public override void Stop()
        {
            throw new System.NotImplementedException();
        }
    }
}
