using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public Animator animator;

    public float moveSpeed = 5f; // 플레이어 이동 속도
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;

    private void Awake() {
        animator = GetComponent<Animator>();
    }
    void Start() {

    }

    void Update() {
        // 공격 트리거 설정
        if (Input.GetKeyDown(KeyCode.Space)) {
            Attack();
        }

        Move();
    }

    void Attack() {
        animator.SetTrigger("attack");

        DetectEnemies();
    }

    void DetectEnemies() {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
        foreach (Collider2D enemy in hitEnemies) {
            Debug.Log("hit");
            enemy.GetComponent<Enemy>().TakeDamage(30);
        }
    }


    private void OnDrawGizmosSelected() {
        if (attackPoint == null) {
            return;
        }
            Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }

    public void Move() {
        // 플레이어 이동 처리
        float moveInput = Input.GetAxisRaw("Horizontal");
        Vector3 moveDirection = new Vector3(moveInput, 0f, 0f);
        transform.position += moveDirection * moveSpeed * Time.deltaTime;

        // 이동 방향에 따라 애니메이션 설정
        if (moveInput != 0f) {
            // 플립 설정
            if (moveInput > 0f) {
                transform.localScale = new Vector3(1f, 1f, 1f);
            }
            else {
                transform.localScale = new Vector3(-1f, 1f, 1f);
            }
        }
    }
}