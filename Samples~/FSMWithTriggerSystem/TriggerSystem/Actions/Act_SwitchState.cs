using Lonfee.TriggerSystem;

namespace Lonfee.FSM.FSMWithTS
{

    public class Act_SwitchState : ABaseEvent
    {
        public System.Action switchAction;

        public override void InitData(object data)
        {
            switchAction = (System.Action)data;
        }

        protected override void DoAction()
        {
            switchAction?.Invoke();
        }
    }
}