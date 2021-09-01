namespace DesignPatterns.Behavioral.State
{
    public class PausedState : GameState
    {
        public PausedState(GameState lastState) : base(lastState.MyContext)
        {
            
        }

        public override void Pause()
        {
            throw new System.NotImplementedException();
        }

        public override void Resume()
        {
            this.Start();
        }

        public override void Start()
        {
            this.MyContext.MyState = new StartedState(this);
        }

        public override void Stop()
        {
            this.MyContext.MyState = new StoppedState(this);
        }
    }
}
