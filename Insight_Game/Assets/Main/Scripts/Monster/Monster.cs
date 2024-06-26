using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Monster 
{
    public abstract class Monster : MonoBehaviour
    {
        public enum State
        {
            Idle,
            Walking,
            Following,
            Attacking,
            Dead,
        }
        public State MonsterState;

        protected Transform target;
        protected int health;
        protected float speed;
        protected float attackRange;
        protected float attackSpeed;
        protected float attackDamage;
    }
}

