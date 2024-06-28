using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MonsterUI : MonoBehaviour {
    [SerializeField] Slider slider;
    [SerializeField] Enemy enemy; // Enemy 스크립트 참조
    private Camera mainCamera; // 메인 카메라 참조
    private Vector3 offset = new Vector3(0, 0.5f, 0); // 슬라이더의 오프셋 값 설정
    private void Awake() {
        slider = GetComponent<Slider>();
    }

    void Start() {
        if (enemy != null) {
            // 초기화 코드 추가 가능
        }
        if (mainCamera == null) {
            mainCamera = Camera.main;
        }
    }

    // Update is called once per frame
    void Update() {
        if (enemy != null) {
            // 월드 좌표를 스크린 좌표로 변환
            Vector3 worldPosition = enemy.transform.position + offset;
            Vector3 screenPosition = mainCamera.WorldToScreenPoint(worldPosition);

            // 슬라이더의 위치를 스크린 좌표로 설정
            slider.transform.position = screenPosition;
        }
    }

    public void FixedUpdate() {
        if (enemy != null) {
            slider.value = (float)enemy.curHealth / enemy.maxHealth; // 슬라이더의 값을 Enemy의 현재 체력으로 업데이트
            if (enemy.curHealth <= 0) {
                gameObject.SetActive(false); // 오브젝트 비활성화
            }
        }
    }
}