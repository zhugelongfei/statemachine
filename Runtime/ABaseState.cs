namespace Lonfee.FSM
{
    public abstract class ABaseState
    {
        private int mType;
        private FiniteStateMachine mFsm;

        protected int StateType
        {
            get { return mType; }
        }

        internal void Init(int type, FiniteStateMachine fsm)
        {
            mType = type;
            mFsm = fsm;
        }

        internal void Update(float deltaTime)
        {
            OnUpdate(deltaTime);

            OnCheckConditions();
        }

        public abstract void OnEnter(params object[] args);

        public abstract void OnUpdate(float deltaTime);

        public abstract void OnExit();

        protected abstract void OnCheckConditions();

        protected void SwitchState(int type, params object[] args)
        {
            mFsm.SwitchState(type, args);
        }
    }
}