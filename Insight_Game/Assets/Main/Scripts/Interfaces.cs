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
    //public Transform Target { set; }

    public void Follow();
}

interface IWalkable
{
    public void Idle();
    public void Walk();
}