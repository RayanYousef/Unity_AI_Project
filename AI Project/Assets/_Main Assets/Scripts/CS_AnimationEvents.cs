using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace AI_Game
{
    public class CS_AnimationEvents : MonoBehaviour
    {

        [SerializeField] UnityEvent event_1,event_2,event_3;

        public void ExcuteEvent_1()
        {
            event_1?.Invoke();
        }

        public void ExcuteEvent_2()
        {
            event_2?.Invoke();
        }

        public void ExcuteEvent_3()
        {
            event_3?.Invoke();
        }



    }
}
