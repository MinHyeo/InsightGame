using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Monster.Goblin
{
    public class GoblinWalk : MonoBehaviour, IWalkable
    {
        Rigidbody2D rigid;
        SpriteRenderer spriter;
        public float Speed { private get; set; }

        public int nextMove;
        public int changeTime;

        private void Awake()
        {
            rigid = GetComponent<Rigidbody2D>();
            spriter = GetComponent<SpriteRenderer>();
        }
        private void Start() { ChangeDirection(); }

        public void Walk()
        {
            spriter.flipX = rigid.velocity.x > 0f ? false : true;
            rigid.velocity = new Vector2(nextMove*2, rigid.velocity.y);

            Vector2 frontVec = new Vector2(rigid.position.x + nextMove * 0.5f, rigid.position.y);
            RaycastHit2D groundInfo = Physics2D.Raycast(frontVec, Vector2.down, 3f);

            if (groundInfo.collider == false)
            {
                nextMove *= -1;
            }

        }
        void ChangeDirection()
        {
            changeTime = Random.Range(1, 4);
            nextMove = Normalize(Random.Range(-5, 5));
            Invoke("ChangeDirection", changeTime);
        }

        int Normalize(float value)
        {
            if (value < -1.67f) return -1;
            else if (value > 1.67f) return 1;
            else return 0;
        }
    } 
}