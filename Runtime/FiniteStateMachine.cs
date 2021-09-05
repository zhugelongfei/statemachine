using System.Collections.Generic;

namespace Lonfee.FSM
{

    public class FiniteStateMachine
    {
        private Dictionary<int, ABaseState> mStateDic;
        private ABaseState mCurState;
        private int mCurStateType;
        private IStateFactory mFactory;
        private bool isRuning;
        private bool mSyncCheck;

        public int CurStateType
        {
            get { return mCurStateType; }
        }

        /// <summary>
        /// set true if you want check conditions on a sync frame when switch to a new state
        /// </summary>
        public bool SyncCheckConditionOnEnter
        {
            get { return mSyncCheck; }
            set { mSyncCheck = value; }
        }

        public FiniteStateMachine(IStateFactory factory = null, int stateDictionaryCapacitySize = 8)
        {
            mFactory = factory;
            mStateDic = new Dictionary<int, ABaseState>(stateDictionaryCapacitySize);
        }

        /// <summary>
        /// Add state by type set.
        /// <para>You must set the factory to fsm.ctor befor use this function</para>
        /// </summary>
        /// <param name="typeSet">type set</param>
        public void AddState(ICollection<int> typeSet)
        {
            if (typeSet == null || typeSet.Count == 0)
                return;

            foreach (var type in typeSet)
            {
                AddState(type);
            }
        }

        /// <summary>
        /// Add state by type
        /// <para>You must set the factory to fsm.ctor befor use this function</para>
        /// </summary>
        /// <param name="type">type of state</param>
        public void AddState(int type)
        {
            if (mFactory == null)
            {
                throw new System.Exception("Lonfee.FSM : You must set the factory to fsm.ctor befor use this function.");
            }

            ABaseState state = mFactory.GenerateState(type);

            AddState(type, state);
        }

        /// <summary>
        /// Add state with you pass in
        /// </summary>
        /// <param name="type">type of state</param>
        /// <param name="state">state object</param>
        public void AddState(int type, ABaseState state)
        {
            if (state == null)
            {
                throw new System.Exception("Lonfee.FSM : State can't be null. Type is : " + type.ToString());
            }

            if (mStateDic.ContainsKey(type))
            {
                throw new System.Exception("Lonfee.FSM : FSM has the same type, Type is : " + type.ToString());
            }

            state.Init(type, this);
            mStateDic.Add(type, state);
        }

        internal void SwitchState(int type, params object[] args)
        {
            // exit pre state
            if (mCurState != null)
            {
                mCurState.OnExit();
                mCurState = null;
            }

            if (!mStateDic.ContainsKey(type) || mStateDic[type] == null)
            {
                throw new System.Exception("Lonfee.FSM : FSM does not contains state which type is : " + type);
            }

            // enter cur state
            mCurStateType = type;
            mCurState = mStateDic[type];
            mCurState.OnEnter(args);

            if (mSyncCheck)
            {
                mCurState.Update(0);
            }
        }

        /// <summary>
        /// Update the current state and check the switch conditions
        /// </summary>
        /// <param name="deltaTime">time of per frame</param>
        public void Update(float deltaTime)
        {
            if (mCurState != null)
                mCurState.Update(deltaTime);
        }

        /// <summary>
        /// Start with the specialy state
        /// </summary>
        /// <param name="type">type of state</param>
        /// <param name="args">enter params</param>
        public void Start(int type, params object[] args)
        {
            if (isRuning)
                return;

            isRuning = true;
            SwitchState(type, args);
        }

        /// <summary>
        /// Stop the current state
        /// </summary>
        public void Stop()
        {
            if (!isRuning)
                return;

            isRuning = false;
            if (mCurState != null)
            {
                mCurState.OnExit();
                mCurState = null;
            }
            mCurStateType = 0;
        }

        /// <summary>
        /// Stop and clear state
        /// </summary>
        public void ClearState()
        {
            Stop();

            mStateDic.Clear();
        }
    }
}