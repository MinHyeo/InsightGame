using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Tilemaps;

namespace Monster.Goblin
{
    public class GoblinMovement : MonoBehaviour, IWalkable, IFollowable
    {
        Rigidbody2D rigid;
        SpriteRenderer spriter;
        Animator animator;
        public Transform Target { private get; set; }
        public float Speed { private get; set; }

        private int nextDir;
        private int changeTime;

        public event UnityAction OnMonsterWalk;
        public event UnityAction OnMonsterIdle;

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
        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Vector3 frontVec = new Vector3(rigid.position.x, rigid.position.y);
            Vector3 moreFrontVec = new Vector3(rigid.position.x + nextDir, rigid.position.y);
            
            Gizmos.DrawLine(frontVec, moreFrontVec);
        }
        public void Idle()
        {
            animator.SetFloat("Velocity", 0);
        }
        public void Walk()
        {
            spriter.flipX = rigid.velocity.x > 0f ? false : true;
            rigid.velocity = new Vector2(nextDir*Speed, rigid.velocity.y);

            //벽 체크 기능으로 나중에 수정
            Vector2 frontVec = new Vector2(rigid.position.x + nextDir * 0.5f, rigid.position.y);
            Vector2 moreFrontVec = new Vector2(nextDir * 0.5f, 0);
            RaycastHit2D groundInfo = Physics2D.Raycast(frontVec, moreFrontVec, 1f, LayerMask.GetMask("Ground"));
            if (groundInfo.collider != null) { Turn(); }

            animator.SetFloat("Velocity", Mathf.Abs(rigid.velocity.x));
        }
        public void Follow()
        {
            nextDir = Target.position.x < transform.position.x ? -1 : 1;
            spriter.flipX = nextDir == 1 ? false : true;
            rigid.velocity = new Vector2(nextDir * Speed, rigid.velocity.y);

            Vector2 frontVec = new Vector2(rigid.position.x + nextDir * 0.5f, rigid.position.y);
            Vector2 moreFrontVec = new Vector2(nextDir * 0.5f, 0);
            RaycastHit2D groundInfo = Physics2D.Raycast(frontVec, moreFrontVec, 1f, LayerMask.GetMask("Ground"));
            if (groundInfo.collider != null) 
            {
                Debug.Log("정지");
                Idle();
            }

            animator.SetFloat("Velocity", Mathf.Abs(rigid.velocity.x));
 
        }
        private void ChangeDirection()
        {
            changeTime = Random.Range(2, 4);
            nextDir = Normalize(Random.Range(-5, 5));
            if(nextDir != 0)
                OnMonsterWalk?.Invoke();
            else if(nextDir == 0)
                OnMonsterIdle?.Invoke();

            Invoke("ChangeDirection", changeTime);
        }
        private int Normalize(float value)
        {
            if (value < -1.67f) return -1;
            else if (value > 1.67f) return 1;
            else return 0;
        }
        private void Turn()
        {
            Debug.Log("턴");
            nextDir *= -1;
            spriter.flipX = nextDir == 1 ? false : true;
            CancelInvoke("ChangeDirection");
            Invoke("ChangeDirection", changeTime);
        }
    } 
}