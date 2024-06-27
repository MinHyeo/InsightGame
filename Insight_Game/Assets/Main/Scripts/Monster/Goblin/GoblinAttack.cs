using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Monster.Goblin
{
    public class GoblinAttack : MonoBehaviour, IAttackable
    {
        Animator anim;
        private void Awake()
        {
            anim = GetComponent<Animator>();
        }
        //�ϵ� �ڵ� �����ؾ� ��
        WaitForSeconds AttackDelay = new WaitForSeconds(1f);
        public IEnumerator AttackCoroutine()
        {
            Attack();
            yield return AttackDelay;
        }

        public void Attack()
        {
            Debug.Log("Player���� ����");
            anim.SetTrigger("Attack");
            Vector2 boxSize = new Vector2(0.1f, 0.3f);
            Collider2D[] collider2Ds = Physics2D.OverlapBoxAll(transform.position + Vector3.right * 0.187f, boxSize, 0);
            foreach (var collider in collider2Ds)
            {
                if (collider.CompareTag("Player"))
                {
                    Debug.Log("Player���� ����");
                }
            }
        }
    }
}
