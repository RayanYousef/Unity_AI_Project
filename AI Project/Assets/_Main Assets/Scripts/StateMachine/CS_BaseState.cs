using Mono.CompilerServices.SymbolWriter;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AI_Game
{


    public abstract class CS_BaseState
    {

        public string name;
        protected SM_BaseCharacter stateMachine;

        public CS_BaseState(string name, SM_BaseCharacter stateMachine)
        {
            this.name = name;
            this.stateMachine = stateMachine;
        }

        public virtual void Enter() { }
        public virtual void Exit() { }
        public virtual void Update() { }    
        public virtual void FixedUpdate() { }


    }
}