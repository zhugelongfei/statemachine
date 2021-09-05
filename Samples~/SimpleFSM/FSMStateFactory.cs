namespace Lonfee.FSM.SimpleFSM
{
    public class FSMStateFactory : IStateFactory
    {
        /*
        private GameObject obj;

        public FSMStateFactory(GameObject obj)
        {
            this.obj = obj
        }
         */

        public ABaseState GenerateState(int type)
        {
            EFSMState state = (EFSMState)type;

            switch (state)
            {
                case EFSMState.Idle:
                    // you can pass field 'obj' to state
                    return new State_Idle();
                case EFSMState.Run:
                    return new State_Run();
                default:
                    return null;
            }
        }
    }
}
