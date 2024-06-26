using UnityEngine;

interface IHittable 
{
    public void Hit();
}
interface ISearchable 
{
    public void Search();
}
interface IAttackable 
{
    public void Attack();
}
interface IFollowable
{
    public void Follow();
}

