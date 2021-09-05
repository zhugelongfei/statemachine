namespace Lonfee.FSM.FSMWithTS
{

    public class FSMStateFactory : IStateFactory
    {
        public ABaseState GenerateState(int type)
        {
            EFSMState state = (EFSMState)type;

            switch (state)
            {
                case EFSMState.Idle:
                    return new State_Idle();
                case EFSMState.Run:
                    return new State_Run();
                default:
                    return null;
            }
        }
    }
}