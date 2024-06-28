using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public abstract class Weapon : MonoBehaviour
{
    
    public float weaponDamage;

    public virtual void Attack() { }
}
