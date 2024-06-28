using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MonsterUI : MonoBehaviour
{
    [SerializeField] Slider slider;
    [SerializeField] Enemy enemy; // Enemy 스크립트 참조
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
            slider.value = enemy.curHealth/enemy.maxHealth; // 슬라이더의 값을 Enemy의 현재 체력으로 업데이트
            if (enemy.curHealth <= 0) {
                gameObject.SetActive(false); // 오브젝트 비활성화
            }
        }
    }
}
