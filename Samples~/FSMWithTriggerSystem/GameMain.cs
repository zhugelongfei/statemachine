/*
 * This sample is very similar to SimpleFSM.
 * But think that, if conditions or actions is very complex,
 * Can coditions and actions be reused? :)
 */

using UnityEngine;
using System.Collections.Generic;
using Lonfee.EventSystem;

namespace Lonfee.FSM.FSMWithTS
{

    public class GameMain : MonoBehaviour
    {
        public UnityEngine.UI.Button switchBtn;
        public UnityEngine.UI.Text stateText;

        private FiniteStateMachine fsm;

        void Start()
        {
            // ui
            switchBtn.onClick.AddListener(OnClk_SwitchState);

            // init fsm
            fsm = new FiniteStateMachine(new FSMStateFactory());
            fsm.AddState(new List<int>() { (int)EFSMState.Idle, (int)EFSMState.Run });
            fsm.Start((int)EFSMState.Idle, "From GameMain.cs");
        }

        void Update()
        {
            fsm.Update(Time.deltaTime);

            stateText.text = "Cur State is :" + ((EFSMState)fsm.CurStateType).ToString();
        }

        private void OnClk_SwitchState()
        {
            EventMgr.Dispatch(new EvtCls.BtnDown());
        }
    }
}