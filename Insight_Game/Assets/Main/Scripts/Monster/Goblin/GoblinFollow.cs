using UnityEngine;

namespace Monster.Goblin
{
    public class GoblinFollow : MonoBehaviour, IFollowable
    {
        public Transform Target { private get; set; }
        public float Speed { private get; set; }
        private SpriteRenderer sprite;
        private int dir;

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
    }

}