using UnityEngine;

namespace Lonfee.FSM.SimpleFSM
{
    public class State_Idle : ABaseState
    {
        public override void OnEnter(params object[] args)
        {
            Debug.Log("Enter idle state. Param is : " + args[0].ToString());
        }

        public override void OnExit()
        {
            Debug.Log("Exit idle state.");
        }

        public override void OnUpdate(float deltaTime)
        {

        }

        protected override void OnCheckConditions()
        {
            // oh, if you want. you can use my triggersystem replace this conditions check.
            if (GameMain.needSwitchState)
            {
                GameMain.needSwitchState = false;
                SwitchState((int)EFSMState.Run, 100);
            }
        }
    }
}
