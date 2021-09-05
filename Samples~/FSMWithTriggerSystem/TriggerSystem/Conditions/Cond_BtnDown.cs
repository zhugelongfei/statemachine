using Lonfee.TriggerSystem;
using Lonfee.EventSystem;
using EvtCls;
using System;

namespace EvtCls
{
    public class BtnDown
    {

    }
}

namespace Lonfee.FSM.FSMWithTS
{

    public class Cond_BtnDown : ABaseCondition
    {
        public override void InitData(object data)
        {

        }

        protected override void OnEnter()
        {
            EventMgr.RegisterEvent<BtnDown>(OnEvt_BtnDown);
        }

        private void OnEvt_BtnDown(BtnDown obj)
        {
            // this cond is success
            IsSuccess = true;
        }

        protected override void OnExit()
        {
            EventMgr.RemoveEvent<BtnDown>(OnEvt_BtnDown);
        }
    }
}
