using Lonfee.TriggerSystem;

namespace Lonfee.FSM.FSMWithTS
{
    public class TSObjFactory : ITSObjGenerator
    {
        public ABaseAction GetActionByType(int type)
        {
            ETSActionType actType = (ETSActionType)type;
            switch (actType)
            {
                case ETSActionType.SwitchState:
                    return new Act_SwitchState();
                default:
                    return null;
            }
        }

        public ABaseCondition GetCondByType(int type)
        {
            ETSConditionType condType = (ETSConditionType)type;
            switch (condType)
            {
                case ETSConditionType.BtnDown:
                    return new Cond_BtnDown();
                default:
                    return null;
            }
        }
    }
}