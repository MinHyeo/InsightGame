using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.Collections.LowLevel.Unsafe;
using UnityEditor.SceneManagement;
using UnityEngine;

[RequireComponent(typeof(MonsterSearch), typeof(MonsterAttack))]
public class Goblin : Monster
{
    private MonsterSearch monsterSearch;
    private MonsterAttack monsterAttack;

    Collider2D collider;

    private void Awake()
    {
        collider = GetComponent<Collider2D>();
        monsterSearch = new MonsterSearch();
        monsterAttack = new MonsterAttack();
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
                monsterSearch.Search(collider);
                break;
            case State.Walking:
                monsterSearch.Search(collider);
                break;
            case State.Attacking:
                break;
            case State.Dead:
                break;
        }
    }
}

public class MonsterSearch : ISearchable
{
    private Vector2 boxCastSize = new Vector2(13f, 1.5f);
    private float boxCastMaxDistance = 10.0f;

    public void Search(Collider2D collider)
    {
        Debug.Log("Monster is searching for the player.");

        RaycastHit2D raycastHit = Physics2D.BoxCast(collider.bounds.center, boxCastSize, 0f, Vector2.down, 0f, LayerMask.GetMask("Player"));
        if(raycastHit.collider != null)
        {
            Debug.Log("Monster found the player.");
        }
    }
}
public class MonsterAttack
{

}