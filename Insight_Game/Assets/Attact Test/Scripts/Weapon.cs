using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public abstract class Weapon : MonoBehaviour
{
    
    public float weaponDamage;
    public int ComboCount;
    public int curentAttack; //ÃÖ´ë ÄÞº¸°ø°Ý È½¼ö
    public float timeSinceAttack;
    public float timeAttackLength;

    public virtual void Attack() { }
    public virtual void Detect() { }
}
