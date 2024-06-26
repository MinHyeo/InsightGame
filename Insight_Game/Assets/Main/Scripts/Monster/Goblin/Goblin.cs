using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.Events;

namespace Monster.Goblin
{
    [RequireComponent(typeof(GoblinSearch), typeof(GoblinAttack), typeof(GoblinFollow))]
    public class Goblin : Monster
    {
        [SerializeField]private GoblinSearch goblinSearch;
        [SerializeField]private GoblinAttack goblinAttack;
        [SerializeField]private GoblinFollow goblinFollw;

        private Collider2D attackPoint;
        private Transform playerTransform;

        private void Awake()
        {
            goblinSearch = GetComponent<GoblinSearch>();
            goblinAttack = GetComponent<GoblinAttack>();
            goblinFollw = GetComponent<GoblinFollow>();

            goblinSearch.PlayerFound += OnPlayerFound;
        }

        private void Start()
        {
            MonsterState = State.Idle;
            health = 100;
            speed = 5.0f;
            attackRange = 2.0f;
            attackSpeed = 1.0f;
            attackDamage = 10.0f;
        }
        private void Update()
        {
            switch (MonsterState)
            {
                case State.Idle:
                    goblinSearch.Search();
                    break;
                case State.Walking:
                    goblinSearch.Search();
                    break;
                case State.Following:
                    goblinFollw.Follow();
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
            MonsterState = State.Following;
            playerTransform = goblinSearch.PlayerTransform;
        }
    }
    
}