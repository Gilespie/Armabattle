using UnityEngine;

public abstract class Enemy : Entity
{
    protected float _damage;
    protected Vector3 _target;

    protected virtual void Update()
    {
        MoveEntity(_target - transform.position);
    }

    protected virtual void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Destructable destructable))
        {
            if (destructable.GetID() != 0)
            {
                destructable.TakeDamage(_damage);
                Destroy(gameObject);
            }
        }
    }
}