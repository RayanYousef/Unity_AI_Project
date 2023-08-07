
using UnityEngine;
using UnityEngine.AI;

namespace AI_Game
{

    [RequireComponent(typeof(CapsuleCollider), typeof(NavMeshAgent))]
    public class SM_BaseCharacter : CS_StateMachine
    {
        [Header("Debug")]
        [SerializeField] Vector3[] path;
        [SerializeField] string currentStateString;

        [Header("Patrolling")]
        [SerializeField] private float movementSpeed = 4;
        [SerializeField] protected float patrollingChangeTargetDistance;
        [SerializeField] protected Transform[] patrolDestinations;


        [Header("Components")]
        protected Transform currentTarget, enemyBase;
        protected NavMeshAgent agent;
        protected CapsuleCollider capCol;
        protected Animator anim;

        [Header("Attack")]
        [SerializeField] 
        protected float attackCD;

        [Header("Detection Spheres")]
        [SerializeField] protected CS_DetectionSphere attackRangeSphere;
        [SerializeField] protected CS_DetectionSphere chaseRangeSphere;

        protected LayerMask enemiesLayer;
        protected Vector3 spheresCenter;
        protected Collider[] enemiesInAttackRange, enemiesInChaseRange;






        [Header("States")]
         //protected State_Patrol patrol;
         protected State_Chase chase;
         protected State_Attack attack;


        public Transform[] PatrolDestinations { get => patrolDestinations;}
        public Transform CurrentTarget { get => currentTarget; set => currentTarget = value; }
        public Transform EnemyBase { get=> enemyBase; set => enemyBase = value; }   
        public NavMeshAgent Agent { get => agent; set => agent = value; }
        public CapsuleCollider CapCol { get => capCol; set => capCol = value; }
        public Collider[] EnemiesInAttackRange { get => enemiesInAttackRange; set => enemiesInAttackRange = value; }
        public Collider[] EnemiesInChaseRange { get => enemiesInChaseRange; set => enemiesInChaseRange = value; }
        public Animator Anim { get => anim; set => anim = value; }

        // States
        //public State_Patrol Patrol { get => patrol; set => patrol = value; }
        public State_Chase Chase { get => chase; set => chase = value; }
        public State_Attack Attack { get => attack; set => attack = value; }


        public LayerMask EnemiesLayer { get => enemiesLayer; }
        public float PatrollingChangeTargetDistance { get => patrollingChangeTargetDistance; }
        public float AttackCD { get => attackCD; set => attackCD = value; }
        public float MovementSpeed { get => movementSpeed; set => movementSpeed = value; }


        #region Awake
        protected void SetEnemyLayer()
        {
            if (gameObject.layer == 6)
            {
                enemiesLayer = 1 << 7;
                enemyBase = GameObject.Find("White Base").transform;
            }
            else
            {
                enemiesLayer = 1 << 6;
                enemyBase = GameObject.Find("Black Base").transform;
            }
        }

        protected void GetComponents()
        {
            agent = GetComponentInChildren<NavMeshAgent>();
            capCol = GetComponentInChildren<CapsuleCollider>();
            anim = GetComponentInChildren<Animator>();
        }
        #endregion

        protected void Awake()
        {
            GetComponents();
            SetEnemyLayer();

           // patrol = new State_Patrol(this);
            chase = new State_Chase(this);
            attack = new State_Attack(this);

            currentState = chase;
 


        }

        private void Start()
        {

            attackRangeSphere.gameObject.layer = gameObject.layer;
            chaseRangeSphere.gameObject.layer = gameObject.layer;
        }

        protected new void Update()
        {

            base.Update();
            if (currentState == chase) currentStateString = "Chase";
            else currentStateString = "Attack";
            if (agent.hasPath && agent.path.status == NavMeshPathStatus.PathComplete)
            {

                for (int i = 0; i <= agent.path.corners.Length - 1; i++)
                {
                    Vector3 currentPoint = agent.path.corners[i];

                    if (i < agent.path.corners.Length - 1)
                    {
                        Vector3 nextPoint = agent.path.corners[i + 1];
                        Debug.DrawLine(currentPoint, nextPoint, Color.white);
                    }
                }

            }
        }
        private new void FixedUpdate()
        {
            Debug.Log("FixedUpdate");
            base.FixedUpdate(); 
            DetectTargetsInChaseRange();
        }


        #region Detect Enemies

        public virtual bool IsCurrentTargetActive()
        {
            if (currentTarget!=null && CurrentTarget.gameObject.activeSelf == false) currentTarget = null;
            return (currentTarget != null && CurrentTarget.gameObject.activeSelf == true);
        }


        public virtual void DetectTargetsInChaseRange()
        {
            float closestDistance = Mathf.Infinity;
            Transform closestEnemy = null;
            foreach (Collider collider in chaseRangeSphere.Colliders)
            {
                if (collider!=null&&collider.TryGetComponent<CS_StatsManager>(out CS_StatsManager statsManager))
                {
                    float distance = Vector3.SqrMagnitude(transform.position - collider.transform.position);

                    if (distance < closestDistance)
                    {

                        if (statsManager.CharType == CharacterType.ground && collider.gameObject.activeSelf)
                        {
                            closestDistance = distance;
                            closestEnemy = collider.transform;
                        }
                    }
                }
            }
            currentTarget = closestEnemy;
        }

        public virtual bool IsCurrentTargetInAttackRange()
        {
            return attackRangeSphere.Colliders.Contains(currentTarget.GetComponent<Collider>());
        }

        #endregion
    }


}