using UnityEditor.U2D.Sprites;
using UnityEngine;

namespace Monster.Goblin
{
    [RequireComponent(typeof(GoblinSearch), typeof(GoblinAttack), typeof(GoblinFollow))]
    public class Goblin : Monster
    {
        [SerializeField]private GoblinSearch goblinSearch;
        [SerializeField]private GoblinAttack goblinAttack;
        [SerializeField]private GoblinFollow goblinFollow;

        private Collider2D attackPoint;

        private void Awake()
        {
            goblinSearch = GetComponent<GoblinSearch>();
            goblinAttack = GetComponent<GoblinAttack>();
            goblinFollow = GetComponent<GoblinFollow>();

            goblinSearch.PlayerFound += OnPlayerFound;
            goblinSearch.PlayerUnfound += OnPlayerUnfound;
        }

        private void Start()
        {
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
            goblinSearch.Search();

            switch (MonsterState)
            {
                case State.Idle:
                    break;
                case State.Walking:
                    break;
                case State.Following:
                    goblinFollow.Follow();
                    break;
                case State.Attacking:
                    goblinAttack.Attack();
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
            MonsterState = State.Idle;
        }
    }
    
}