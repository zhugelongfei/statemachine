using UnityEngine;

namespace Lonfee.FSM.SimpleFSM
{
    public class State_Run : ABaseState
    {
        public override void OnEnter(params object[] args)
        {
            Debug.Log("Enter run state. Param is :" + args[0].ToString());
        }

        public override void OnExit()
        {
            Debug.Log("Exit run state.");
        }

        public override void OnUpdate(float deltaTime)
        {

        }

        protected override void OnCheckConditions()
        {
            if (GameMain.needSwitchState)
            {
                GameMain.needSwitchState = false;
                SwitchState((int)EFSMState.Idle, "From run state");
            }
        }
    }
}
