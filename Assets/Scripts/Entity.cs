using UnityEngine;

public abstract class Entity : Destructable
{
    [SerializeField] protected float _walkSpeed = 5f;
    protected float _currentSpeed = 0;

    protected virtual void MoveEntity()
    {

    }

    public virtual void MoveEntity(Vector3 dir)
    {

    }

    protected virtual void Shoot()
    {
        //delete from here
    }
}