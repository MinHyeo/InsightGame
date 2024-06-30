using UnityEngine;
using UnityEngine.Events;

namespace Monster.Goblin
{
    public class GoblinFollow : MonoBehaviour, IFollowable
    {
        public Transform Target { private get; set; }
        public float Speed { private get; set; }
        private SpriteRenderer sprite;
        private int dir;

        private Vector2 boxSize = new Vector2(0.1f, 0.3f);
        public event UnityAction PlayerAttacked;
        public event UnityAction PlayerUnAttacked;

        private void Awake()
        {
            sprite = GetComponent<SpriteRenderer>();
        }

        public void Follow()
        {
            dir = Target.position.x < transform.position.x ? 1 : -1;
            sprite.flipX = dir == 1 ? true : false;
            transform.position = Vector2.MoveTowards(transform.position, Target.position, Speed * Time.deltaTime);
        }
        public void CheckAttackable()
        {
            RaycastHit2D raycastHit2D = Physics2D.BoxCast(transform.position, boxSize, 0f, Vector2.right * dir, 0f, LayerMask.GetMask("Player"));
            if (raycastHit2D.collider != null)
            {
                Debug.Log("공격 가능");
                PlayerAttacked?.Invoke();
            }
            else
            {
                Debug.Log("공격 불가능");
                PlayerUnAttacked?.Invoke();
            }
        }
    }

}