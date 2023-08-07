using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace AI_Game
{
    public class State_Patrol : CS_BaseState
    {
        private new SM_BaseCharacter stateMachine;
        private int currentCounter;

        public State_Patrol(SM_BaseCharacter stateMachine) : base("Patrol", stateMachine)
        {
            this.stateMachine = stateMachine;
        }

        public override void Update()
        {
            if (stateMachine.EnemiesInChaseRange.Length>0)
            {
                stateMachine.ChangeMachineState(stateMachine.Chase);
                return;
            }

            if (Vector3.SqrMagnitude(stateMachine.CurrentTarget.transform.position - stateMachine.transform.position) < stateMachine.PatrollingChangeTargetDistance)
            {
                ChangeTarget();
            }
            else
            {
                stateMachine.Agent.SetDestination(stateMachine.CurrentTarget.transform.position);
            }

        }


        public void ChangeTarget()
        {
            int randomNumber;
            do
            {
                randomNumber = Random.Range(0, stateMachine.PatrolDestinations.Length);

            } while (currentCounter == randomNumber);


            currentCounter = randomNumber;

            stateMachine.CurrentTarget = stateMachine.PatrolDestinations[currentCounter];
        }

        //private void OldBehavior()
        //{
        //    if (Vector3.SqrMagnitude(stateMachine.CurrentTarget.transform.position - stateMachine.transform.position) < 0.1f)
        //    {
        //        stateMachine.ChangeTarget();
        //    }
        //    else
        //    {
        //        stateMachine.transform.rotation = Quaternion.LookRotation(stateMachine.CurrentTarget.position - stateMachine.transform.position);
        //        stateMachine.transform.position = Vector3.MoveTowards(stateMachine.transform.position, stateMachine.CurrentTarget.transform.position, stateMachine.MovementSpeed * Time.deltaTime);
        //    }
        //}
    }

}