using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AI_Game
{
    public class SM_RangedCharacter : SM_BaseCharacter
    {
        [Header("Attack Range Sphere Radius")]
        [SerializeField] Transform magicBallPrefab;
        [SerializeField] Vector3 magicBallOffset;


        // Start is called before the first frame update
        void Start()
        {
            
            magicBallPrefab.gameObject.layer = gameObject.layer;
            if (gameObject.layer == LayerMask.NameToLayer("White"))
                magicBallPrefab.GetComponent<MeshRenderer>().material.color = Color.blue;
            else magicBallPrefab.GetComponent<MeshRenderer>().material.color = Color.red;
            magicBallPrefab.gameObject.SetActive(false);


            magicBallPrefab.transform.parent = GameObject.Find("Projectiles").transform;
            currentState.Enter();
        }

        new void Awake()
        {
            base.Awake();
        }
        // Update is called once per frame
        new void Update()
        {
            base.Update();

        }


        public void OnAttack()
        {
            if (currentTarget != null)
            {
                magicBallPrefab.gameObject.SetActive(true);
                magicBallPrefab.GetComponent<Rigidbody>().velocity = Vector3.zero;
                magicBallPrefab.position = currentTarget.position + magicBallOffset;
            }
        }



        public override void DetectTargetsInChaseRange()
        {
            float closestDistance = Mathf.Infinity;
            Transform closestEnemy = null;
            foreach (Collider collider in chaseRangeSphere.Colliders)
            {
                if (collider != null && collider.TryGetComponent<CS_StatsManager>(out CS_StatsManager statsManager))
                {
                    float distance = Vector3.SqrMagnitude(Agent.transform.position - collider.transform.position);

                    if (distance < closestDistance)
                    {
                        if (collider.gameObject.activeSelf)
                        {
                            closestDistance = distance;
                            closestEnemy = collider.transform;
                        }
                    }
                }
            }
            currentTarget = closestEnemy;
        }



        #region Old
        //public override void CheckEnemiesInChaseRange()
        //{
        //    // Sphere Dimensions
        //    spheresCenter = capCol.bounds.center;
        //    enemiesInChaseRange = Physics.OverlapSphere(spheresCenter, chaseSphereRadius, enemiesLayer);
        //    float closestDistance = Mathf.Infinity;
        //    Transform closestEnemy = null;
        //    foreach (Collider collider in enemiesInChaseRange)
        //    {
        //        float distance = Vector3.SqrMagnitude(Agent.transform.position - collider.transform.position);

        //        if (distance < closestDistance)
        //        {
        //            if (collider.TryGetComponent<CS_StatsManager>(out CS_StatsManager statsManager) == true
        //                && statsManager.CharType == CharacterType.ground && collider.gameObject.activeSelf)
        //            {
        //                closestDistance = distance;
        //                closestEnemy = collider.transform;
        //            }
        //        }
        //    }
        //    currentTarget = closestEnemy;
        //}

        //public override bool IsCurrentTargetInAttackRange()
        //{
        //    bool InRange = false;
        //    // Sphere Dimensions
        //    spheresCenter = capCol.bounds.center;
        //    enemiesInAttackRange = Physics.OverlapSphere(spheresCenter, attackSphereRadius, enemiesLayer);
        //    if (enemiesInAttackRange.Length > 0)
        //    {
        //        foreach (Collider collider in enemiesInAttackRange)
        //        {
        //            if (collider.transform == currentTarget) InRange = true;
        //        }
        //    }

        //    return InRange;
        //}
        #endregion

        //#region Gizmo
        //protected void OnDrawGizmosSelected()
        //{

        //    Gizmos.color = Color.white;
        //    Gizmos.DrawWireSphere(checkSpheresCenter, chaseSphereRadius);

        //    Gizmos.color = Color.cyan;
        //    Gizmos.DrawWireSphere(checkSpheresCenter, attackSphereRadius);

        //} 
        //#endregion

    }
}
