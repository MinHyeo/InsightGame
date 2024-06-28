using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour {

    public float maxHealth = 100;
    public float curHealth;

    void Awake() {
    }

    void Start() {
        curHealth = maxHealth;
    }

    void Update() {
    }

    public void TakeDamage(float damage) {
        curHealth -= damage;
        if (curHealth <= 0) {
            gameObject.SetActive(false); // 오브젝트 비활성화
        }
    }

}