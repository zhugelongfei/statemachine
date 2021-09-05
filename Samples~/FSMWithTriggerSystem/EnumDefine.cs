namespace Lonfee.FSM.FSMWithTS
{
    public enum EFSMState
    {
        Idle = 1,
        Run = 2,
    }

    public enum ETSConditionType
    {
        BtnDown = 1,

        // not implement
        // HPIsZero,
        // MPIsFull,
        // ...
    }

    public enum ETSActionType
    {
        SwitchState = 1,
    }
}