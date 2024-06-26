using UnityEngine;

interface IHittable 
{
    public void Hit();
}
interface ISearchable 
{
    public void Search(Collider2D collider);
}
interface IAttackable 
{
    public void Attack();
}

