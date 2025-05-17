using UnityEngine;

public abstract class Entity : Destructable
{
    [SerializeField] protected float _speed = 5f;
    [SerializeField] protected float _currentSpeed = 0;
    [SerializeField] protected float _damage = 5f;

    protected virtual void MoveEntity()
    {

    }

    protected virtual void Shoot()
    {

    }
}