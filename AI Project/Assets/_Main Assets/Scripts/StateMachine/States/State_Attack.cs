
using UnityEngine;


namespace AI_Game
{
    public class State_Attack : CS_BaseState
    {
        private new SM_BaseCharacter stateMachine;
        private float timer;

        public State_Attack(SM_BaseCharacter stateMachine) : base("Attack", stateMachine)
        {
            this.stateMachine = stateMachine;
        }



        public override void Enter()
        {
            Debug.Log("Entered Attack State");
            stateMachine.Anim.SetBool("Run", false);
            stateMachine.Agent.speed = 0;
            stateMachine.Agent.velocity = Vector3.zero;
        }

        public override void Update()
        {
            if (stateMachine.CurrentTarget!=null && !stateMachine.IsCurrentTargetInAttackRange() || stateMachine.CurrentTarget==null)
            {
                stateMachine.ChangeMachineState(stateMachine.Chase);
                return;
            }

        }

        public override void FixedUpdate()
        {
            timer+= Time.deltaTime;
            if(timer>stateMachine.AttackCD)
            {
                stateMachine.IsCurrentTargetActive();
                if(stateMachine.CurrentTarget!=null) 
                stateMachine.transform.rotation = Quaternion.LookRotation(stateMachine.CurrentTarget.position - stateMachine.transform.position, Vector3.up);
                stateMachine.Anim.SetTrigger("Attack");
                timer= 0;
            }
            base.FixedUpdate();


        }

        public override void Exit()
        {
          //  stateMachine.Player.transform.GetComponent<Renderer>().material.color = Color.white;
        }



    }


}