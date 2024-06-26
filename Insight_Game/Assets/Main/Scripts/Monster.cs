using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    public enum State {
        Idle,
        Walking,
        Attacking,
        Dead,
    }
    public State MonsterState;
    
    protected int health;
    protected float speed;
    protected float attackRange;
    protected float attackSpeed;
    protected float attackDamage;
}