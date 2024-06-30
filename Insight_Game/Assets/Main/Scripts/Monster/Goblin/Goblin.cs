using System.Collections;
using UnityEditor.U2D.Sprites;
using UnityEngine;

namespace Monster.Goblin
{
    [RequireComponent(typeof(GoblinSearch), typeof(GoblinAttack), typeof(GoblinFollow))]
    [RequireComponent (typeof(GoblinWalk))]
    public class Goblin : Monster
    {
        [SerializeField] private GoblinSearch goblinSearch;
        [SerializeField] private GoblinAttack goblinAttack;
        [SerializeField] private GoblinFollow goblinFollow;
        [SerializeField] private GoblinWalk goblinWalk;

        private Collider2D attackPoint;

        private void Awake()
        {
            goblinSearch = GetComponent<GoblinSearch>();
            goblinAttack = GetComponent<GoblinAttack>();
            goblinFollow = GetComponent<GoblinFollow>();
            goblinWalk = GetComponent<GoblinWalk>();

            goblinSearch.PlayerFound += OnPlayerFound;
            goblinSearch.PlayerUnfound += OnPlayerUnfound;
        }

        private void Start()
        {
            StateInit();
        }
        protected override void StateInit()
        {
            checkAttackable = GetComponentInChildren<CheckAttackable>();
            checkAttackable.PlayerAttacked += OnPlayerAttack;
            checkAttackable.PlayerUnAttacked += OnPlayerUnAttack;

            MonsterState = State.Idle;
            health = 100;
            speed = 2.0f;
            attackRange = 2.0f;
            attackSpeed = 1.0f;
            attackDamage = 10.0f;

            goblinFollow.Speed = speed;
        }
        private void Update()
        {
            Debug.Log(MonsterState);

            switch (MonsterState)
            {
                case State.Idle:
                    goblinSearch.Search();
                    break;
                case State.Walking:
                    goblinSearch.Search();
                    goblinWalk.Walk();
                    break;
                case State.Following:
                    goblinSearch.Search();
                    goblinFollow.Follow();
                    break;
                case State.Attacking:
                    StartCoroutine(goblinAttack.AttackCoroutine());
                    break;
                case State.Dead:
                    break;
            }
        }

        private void OnPlayerFound()
        {
            this.target = goblinSearch.Target;
            goblinFollow.Target = target;
            MonsterState = State.Following;
        }
        private void OnPlayerUnfound()
        {
            this.target = null;
            goblinFollow.Target = null;
            //MonsterState = State.Idle;
            MonsterState = State.Walking;
        }
        private void OnPlayerAttack()
        {
            MonsterState = State.Attacking;
        }
        private void OnPlayerUnAttack()
        {
            MonsterState = State.Following;
        }
    }
}