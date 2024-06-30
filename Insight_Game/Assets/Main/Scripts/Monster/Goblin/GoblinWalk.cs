using UnityEngine;

namespace Monster.Goblin
{
    public class GoblinWalk : MonoBehaviour, IWalkable
    {
        Rigidbody2D rigid;
        SpriteRenderer spriter;
        Animator animator;
        public float Speed { private get; set; }

        private int nextDir;
        private int changeTime;

        private void Awake()
        {
            rigid = GetComponent<Rigidbody2D>();
            spriter = GetComponent<SpriteRenderer>();
            animator = GetComponent<Animator>();
        }
        private void Start() 
        { 
            ChangeDirection();
        }

        public void Walk()
        {
            spriter.flipX = rigid.velocity.x > 0f ? false : true;
            rigid.velocity = new Vector2(nextDir*2, rigid.velocity.y);

            Vector2 frontVec = new Vector2(rigid.position.x + nextDir * 0.5f, rigid.position.y);
            RaycastHit2D groundInfo = Physics2D.Raycast(frontVec, Vector2.down, 3f);
            if (groundInfo.collider == false) { nextDir *= -1; }

            animator.SetFloat("Velocity", Mathf.Abs(rigid.velocity.x));

        }
        private void ChangeDirection()
        {
            changeTime = Random.Range(1, 4);
            nextDir = Normalize(Random.Range(-5, 5));
            Invoke("ChangeDirection", changeTime);
        }

        private int Normalize(float value)
        {
            if (value < -1.67f) return -1;
            else if (value > 1.67f) return 1;
            else return 0;
        }
    } 
}