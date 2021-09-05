using System.Collections.Generic;
using UnityEngine;

namespace Lonfee.FSM.SimpleFSM
{
    public class GameMain : MonoBehaviour
    {
        public UnityEngine.UI.Button switchBtn;
        public UnityEngine.UI.Text stateText;

        private FiniteStateMachine fsm;
        public static bool needSwitchState = false;

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
            // use event system replace it!
            // this is only for test!!!!!!
            needSwitchState = true;
        }

    }
}