using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    Rigidbody2D rigid;
    Animator anim;
    SpriteRenderer spriter;

    public enum MonsterState
    {
        Idle,
        Patrol,
        Chase,
        Attack,
        Flee,
        Search,
        Dead
    }

    public MonsterState currentState = MonsterState.Idle;
    public int nextMove;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        spriter = GetComponent<SpriteRenderer>();

        Invoke("ChangeState", 1);
    }

    private void FixedUpdate()
    {
        switch (currentState)
        {
            case MonsterState.Idle:
                Idle();
                break;
            case MonsterState.Patrol:
                Patrol();
                break;
        }
    }

    private void LateUpdate()
    {
        anim.SetFloat("velocity", rigid.velocity.magnitude);

        if (rigid.velocity.x != 0)
        {
            spriter.flipX = rigid.velocity.x < 0;
        }
    }

    void Think()
    {
        nextMove = Random.Range(-1, 2);
        Invoke("Think", 4);
    }

    void Idle()
    {
        rigid.velocity = new Vector2(0, rigid.velocity.y);
    }

    void Patrol()
    {
        if (currentState == MonsterState.Patrol)
        {
            rigid.velocity = new Vector2(nextMove, rigid.velocity.y);

            Vector2 frontVec = new Vector2(rigid.position.x + nextMove * 0.5f, rigid.position.y);
            RaycastHit2D groundInfo = Physics2D.Raycast(frontVec, Vector2.down, 3f);

            if (groundInfo.collider == false)
            {
                nextMove *= -1;
                CancelInvoke();
                Invoke("Think", 4);
            }
        }
    }


    void ChangeState()
    {
        if (currentState == MonsterState.Idle)
        {
            currentState = MonsterState.Patrol;
            Invoke("Think", 0); // 깨어날 때 즉시 Think 실행
        }
        else
        {
            currentState = MonsterState.Idle;
        }

        // 다음 상태 변경 예약
        Invoke("ChangeState", 4);
    }
}