using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    Rigidbody2D rigid;
    Animator anim;
    SpriteRenderer spriter;

    public int nextMove;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        spriter = GetComponent<SpriteRenderer>();

        Invoke("Think", 4);
    }
    void FixedUpdate()
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

    void LateUpdate()
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

        Vector2 frontVec = new Vector2(rigid.position.x + nextMove * 0.5f, rigid.position.y);
    }
}
