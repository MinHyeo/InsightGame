using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public Animator animator;
    public float moveSpeed = 5f; // �÷��̾� �̵� �ӵ�
    public LayerMask enemyLayers;
    public Rigidbody2D PlayerRigidbody;
    public float jumpForce = 5f;

    public Weapon weapon;
    private void Awake() {
        animator = GetComponent<Animator>();
        weapon = GetComponentInChildren<Weapon>();
        PlayerRigidbody = GetComponent<Rigidbody2D>();
    }
    void Start() {

    }

    void Update() {
        if (Input.GetMouseButtonDown(0)) {
            weapon.Attack();
        }
        else if (Input.GetKeyDown(KeyCode.Space)) {
            Jump();
        }

        Move();
    }

    void WeaponDetect() {
        weapon.Detect();
        Debug.Log("�ִϸ��̼� �̺�Ʈ Ŭ�� �ߵ�");
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
    void Jump() {
        PlayerRigidbody.velocity = new Vector2(PlayerRigidbody.velocity.x, jumpForce);
        
        Debug.Log("Jump!");
    }
}