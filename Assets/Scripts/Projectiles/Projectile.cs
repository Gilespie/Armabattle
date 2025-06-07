using UnityEngine;

public abstract class Projectile : MonoBehaviour
{
    [SerializeField] protected float _lifeTime = 5f;
    [SerializeField] protected float _damage = 15f;
    [SerializeField] protected float _speed = 30f;
    protected Rigidbody _rigidbody;

    protected virtual void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();    
        Destroy(gameObject, _lifeTime);
    }

    protected virtual void FixedUpdate()
    {
        MoveProject();
    }

    protected virtual void MoveProject()
    {
        Vector3 dir = (transform.forward).normalized;

        _rigidbody.MovePosition(transform.position + dir * _speed * Time.fixedDeltaTime);
    }

    protected virtual void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.TryGetComponent(out Destructable destructable))
        {
            destructable.TakeDamage(_damage);
            Destroy(gameObject);
        }
    }
}