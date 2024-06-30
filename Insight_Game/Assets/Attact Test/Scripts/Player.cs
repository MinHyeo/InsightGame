using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public Animator animator;
    public float moveSpeed = 5f; // 플레이어 이동 속도
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
        Debug.Log("애니메이션 이벤트 클립 발동");
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
    void Jump() {
        PlayerRigidbody.velocity = new Vector2(PlayerRigidbody.velocity.x, jumpForce);
        
        Debug.Log("Jump!");
    }
}