using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    public Animator animator;
    public GameObject attackCollider; // 공격 판정 콜라이더
    public float moveSpeed = 5f; // 플레이어 이동 속도

    void Start() {
        animator = GetComponent<Animator>();
        attackCollider.SetActive(false);
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
    }

    // 애니메이션 이벤트에서 호출될 함수 (공격 시작 시)
    public void EnableAttackCollider() {
        attackCollider.SetActive(true);
    }

    // 애니메이션 이벤트에서 호출될 함수 (공격 종료 시)
    public void DisableAttackCollider() {
        attackCollider.SetActive(false);
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