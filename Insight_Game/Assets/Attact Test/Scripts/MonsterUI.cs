using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MonsterUI : MonoBehaviour
{
    [SerializeField] Slider slider;
    [SerializeField] Enemy enemy; // Enemy ��ũ��Ʈ ����
    private void Awake() {
        slider = GetComponent<Slider>();
    }
    void Start()
    {
        if(enemy != null) { 
            
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void FixedUpdate() {
        if (enemy != null) {
            slider.value = enemy.curHealth/enemy.maxHealth; // �����̴��� ���� Enemy�� ���� ü������ ������Ʈ
            if (enemy.curHealth <= 0) {
                gameObject.SetActive(false); // ������Ʈ ��Ȱ��ȭ
            }
        }
    }
}
