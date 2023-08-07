
using UnityEngine;
using UnityEngine.AI;


namespace AI_Game
{
    public class State_Chase : CS_BaseState
    {
        private new SM_BaseCharacter stateMachine;

        public State_Chase(SM_BaseCharacter stateMachine) : base("Chase", stateMachine)
        {
            this.stateMachine = stateMachine;
        }

        public override void Enter()
        {

            Debug.Log(stateMachine.gameObject.name);
            Debug.Log("Entered Chase State");
            base.Enter();

            stateMachine.Anim.SetBool("Run", true);
            stateMachine.Agent.speed = stateMachine.MovementSpeed;


            if(stateMachine.CurrentTarget == null)
            stateMachine.Agent.SetDestination(stateMachine.EnemyBase.transform.position);
            else stateMachine.Agent.SetDestination(stateMachine.CurrentTarget.transform.position);


        }

        public override void Update()
        {

          
        }

        public override void FixedUpdate()
        {
            base.FixedUpdate();

            //if (stateMachine.CurrentTarget == null)
            //{
            //    stateMachine.DetectTargetsInChaseRange();
                if (stateMachine.CurrentTarget != null)
                {
                    stateMachine.Agent.SetDestination(stateMachine.CurrentTarget.transform.position);

                }
            //}

            if (stateMachine.CurrentTarget != null && stateMachine.IsCurrentTargetInAttackRange())
                stateMachine.ChangeMachineState(stateMachine.Attack);

            if(stateMachine.Agent.pathStatus == NavMeshPathStatus.PathComplete && stateMachine.CurrentTarget != null)
                stateMachine.Agent.SetDestination(stateMachine.CurrentTarget.transform.position);
            else if (stateMachine.Agent.pathStatus == NavMeshPathStatus.PathComplete)
                stateMachine.Agent.SetDestination(stateMachine.EnemyBase.transform.position);

            stateMachine.IsCurrentTargetActive();




        }

        public override void Exit()
        {
            stateMachine.Anim.SetBool("Run", false);
            base.Exit();

        }



        private void OldFunction()
        {
            //if (stateMachine.DistanceOfTarget < stateMachine.AttackDistance)
            //{
            //    stateMachine.ChangeMachineState(stateMachine.Attack);

            //    return;
            //}
            //else
            //{
            //    if (stateMachine.CurrentTarget != null)
            //    {
            //        stateMachine.Agent.SetDestination(stateMachine.CurrentTarget.transform.position);

            //        stateMachine.EnemiesInChaseRange();
            //        stateMachine.EnemiesInAttackRange();
            //    }
            //}
        }
    }


}