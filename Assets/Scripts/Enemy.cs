using UnityEngine;

public abstract class Enemy : Entity
{
    [SerializeField] protected float _damage = 5f;
    protected Vector3 _target;

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