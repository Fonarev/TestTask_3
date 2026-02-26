namespace Assets.Test.Scripts.FSM
{
    public class State 
    {
        protected FSM _fsm;

        public State(FSM fsm) => _fsm = fsm;

        public virtual void Enter() { }

        public virtual void Exit() { }

        public virtual void UpDate(float deltaTime) { }
    }
}