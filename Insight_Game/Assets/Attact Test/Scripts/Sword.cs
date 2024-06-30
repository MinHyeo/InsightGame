using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : Weapon {
    public Transform[] attackPoints;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;

    public Animator playerAnimator;

    private void Awake() {
        attackPoints = GetComponentsInChildren<Transform>();
        playerAnimator = GetComponentInParent<Animator>();
    }
    void Start() {
        weaponDamage = 10;
        ComboCount = 3;
        timeSinceAttack = 0;
        timeAttackLength = 0.3f;
    }


    void Update() {
        timeSinceAttack += Time.deltaTime;
    }

    public override void Detect() {
        Debug.Log("Àû Å½Áö");
        if (attackPoints != null) {
            Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoints[1].position, attackRange, enemyLayers);
            foreach (Collider2D enemy in hitEnemies) {
                Debug.Log("Àû ¸ÂÀ½");
                enemy.GetComponent<Enemy>().TakeDamage(weaponDamage);
            }
        }
    }
    public override void Attack() {
        if (timeSinceAttack > timeAttackLength) {
            curentAttack++;

            if (curentAttack > ComboCount) { curentAttack = 1; }
            if (timeSinceAttack > 1.0f) { curentAttack = 1; }

            playerAnimator.SetTrigger("Attack" + curentAttack);
            timeSinceAttack = 0.0f;


            Debug.Log("ÇöÀç ÄÞº¸: "+curentAttack);
        }
    }

    void OnDrawGizmosSelected() {
        Gizmos.color = Color.red;
        for (int i = 1; i < attackPoints.Length; i++) {
            Gizmos.DrawWireSphere(attackPoints[i].position, attackRange);
        }
    }
}
