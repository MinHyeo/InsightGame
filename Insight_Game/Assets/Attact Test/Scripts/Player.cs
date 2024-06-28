using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public Animator animator;

    public float moveSpeed = 5f; // �÷��̾� �̵� �ӵ�
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;

    private void Awake() {
        animator = GetComponent<Animator>();
    }
    void Start() {

    }

    void Update() {
        // ���� Ʈ���� ����
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
        // �÷��̾� �̵� ó��
        float moveInput = Input.GetAxisRaw("Horizontal");
        Vector3 moveDirection = new Vector3(moveInput, 0f, 0f);
        transform.position += moveDirection * moveSpeed * Time.deltaTime;

        // �̵� ���⿡ ���� �ִϸ��̼� ����
        if (moveInput != 0f) {
            // �ø� ����
            if (moveInput > 0f) {
                transform.localScale = new Vector3(1f, 1f, 1f);
            }
            else {
                transform.localScale = new Vector3(-1f, 1f, 1f);
            }
        }
    }
}