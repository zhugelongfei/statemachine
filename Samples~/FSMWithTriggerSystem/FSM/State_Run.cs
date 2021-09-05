using System.Collections.Generic;
using Lonfee.TriggerSystem;

namespace Lonfee.FSM.FSMWithTS
{
    public class State_Run : ABaseState
    {
        private Trigger_CA ts;

        public State_Run()
        {
            CAData data = new CAData();
            data.condColl = new List<CondCtorData>()
            {
                new CondCtorData((int)ETSConditionType.BtnDown),
            };
            data.actColl = new List<ActionCtorData>()
            {
                new ActionCtorData((int)ETSActionType.SwitchState, (System.Action)SwitchToIdle),
            };

            // there can has many trigger, if you need.
            ts = new Trigger_CA(new TSObjFactory(), data);
        }

        public override void OnEnter(params object[] args)
        {
            ts.Start();
        }

        public override void OnExit()
        {
            ts.Stop();
        }

        public override void OnUpdate(float deltaTime)
        {

        }

        protected override void OnCheckConditions()
        {
            ts.Update(UnityEngine.Time.deltaTime);
        }

        private void SwitchToIdle()
        {
            SwitchState((int)EFSMState.Idle, "From run");
        }
    }
}
