namespace Lonfee.FSM
{
    public interface IStateFactory
    {
        ABaseState GenerateState(int type);
    }
}