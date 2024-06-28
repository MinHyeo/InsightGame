using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public Animator animator;
    public float moveSpeed = 5f; // �÷��̾� �̵� �ӵ�
    public LayerMask enemyLayers;
    public Weapon weapon;

    private void Awake() {
        animator = GetComponent<Animator>();
        weapon = GetComponentInChildren<Weapon>();
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
    }

    void WeaponAttack() {
        weapon.Attack();
        Debug.Log("Animaion clip start");
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