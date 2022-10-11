using System;

namespace DesignPatterns.Behavioral.State
{
    public class StartedState : GameState
    {
        public StartedState(GameState lastState) : base(lastState.MyContext)
        {
        }
        public override void Pause()
        {
            this.MyContext.MyState = new PausedState(this);
        }

        public override void Resume()
        {
            throw new System.NotImplementedException();
        }

        public override void Start()
        {
            throw new System.NotImplementedException();
        }        

        public override void Stop()
        {
            this.MyContext.MyState = new StoppedState(this);
        }
    }
}
