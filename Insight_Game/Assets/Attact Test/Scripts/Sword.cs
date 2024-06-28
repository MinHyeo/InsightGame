using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : Weapon
{
    public Transform[] attackPoints;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;

    private void Awake() {
        attackPoints = GetComponentsInChildren<Transform>();
    }
    void Start()
    {
        weaponDamage = 30;
    }

    
    void Update()
    {
        
    }

    public  override void  Attack() {
        Debug.Log("detect");
        if (attackPoints != null) {
            Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoints[1].position, attackRange, enemyLayers);
            foreach (Collider2D enemy in hitEnemies) {
                Debug.Log("Enemy hit");
                enemy.GetComponent<Enemy>().TakeDamage(weaponDamage);
            }
        }
    }
}
