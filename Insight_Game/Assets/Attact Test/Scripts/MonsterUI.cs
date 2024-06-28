using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MonsterUI : MonoBehaviour {
    [SerializeField] Slider slider;
    [SerializeField] Enemy enemy; // Enemy ��ũ��Ʈ ����
    private Camera mainCamera; // ���� ī�޶� ����
    private Vector3 offset = new Vector3(0, 0.5f, 0); // �����̴��� ������ �� ����
    private void Awake() {
        slider = GetComponent<Slider>();
    }

    void Start() {
        if (enemy != null) {
            // �ʱ�ȭ �ڵ� �߰� ����
        }
        if (mainCamera == null) {
            mainCamera = Camera.main;
        }
    }

    // Update is called once per frame
    void Update() {
        if (enemy != null) {
            // ���� ��ǥ�� ��ũ�� ��ǥ�� ��ȯ
            Vector3 worldPosition = enemy.transform.position + offset;
            Vector3 screenPosition = mainCamera.WorldToScreenPoint(worldPosition);

            // �����̴��� ��ġ�� ��ũ�� ��ǥ�� ����
            slider.transform.position = screenPosition;
        }
    }

    public void FixedUpdate() {
        if (enemy != null) {
            slider.value = (float)enemy.curHealth / enemy.maxHealth; // �����̴��� ���� Enemy�� ���� ü������ ������Ʈ
            if (enemy.curHealth <= 0) {
                gameObject.SetActive(false); // ������Ʈ ��Ȱ��ȭ
            }
        }
    }
}