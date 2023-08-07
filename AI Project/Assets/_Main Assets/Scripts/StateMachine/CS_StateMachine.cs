using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AI_Game
{


    public class CS_StateMachine : MonoBehaviour
    {
        protected CS_BaseState currentState;
        
        public void ChangeMachineState(CS_BaseState newState)
        {

            currentState.Exit();
            currentState = newState;
            currentState.Enter();
        }

        public void Update()
        {
            if (currentState != null)
            {
                currentState.Update();
            }
        }

        public void FixedUpdate()
        {
            if (currentState != null)
            {
                currentState.FixedUpdate();
            }
        }

    }


}