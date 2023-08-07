using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AI_Game
{
    public class SM_MeleeCharacter : SM_BaseCharacter
    {

        // Start is called before the first frame update
        void Start()
        {
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


        #region Old
        //public override void CheckEnemiesInChaseRange()
        //{
        //    // Sphere Dimensions
        //    Debug.Log("Check enemies in range");
        //    spheresCenter = capCol.bounds.center;
        //    enemiesInChaseRange = Physics.OverlapSphere(spheresCenter, chaseSphereRadius, enemiesLayer);
        //    float closestDistance = Mathf.Infinity;
        //    Transform closestEnemy = null;
        //    foreach (Collider collider in enemiesInChaseRange)
        //    {
        //        float distance = Vector3.SqrMagnitude(transform.position - collider.transform.position);

        //        if (distance < closestDistance)
        //        {
        //            if(collider.TryGetComponent<CS_StatsManager>(out CS_StatsManager statsManager) == true 
        //                && statsManager.CharType == CharacterType.ground && collider.gameObject.activeSelf)
        //            {
        //                closestDistance = distance;
        //                closestEnemy = collider.transform;
        //            }

        //        }
        //    }
        //    currentTarget = closestEnemy;

        //}
        //protected void OnDrawGizmosSelected()
        //{

        //    Gizmos.color = Color.white;
        //    Gizmos.DrawWireSphere(transform.position, chaseSphereRadius);

        //}
        #endregion


    }
}
