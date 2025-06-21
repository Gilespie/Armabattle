using UnityEngine;

public abstract class Projectile : MonoBehaviour
{
    [SerializeField] protected float _lifeTime = 5f;
    [SerializeField] protected float _damage = 15f;
    [SerializeField] protected float _speed = 30f;
    [SerializeField] private bool _isGranade = false;
    protected Rigidbody _rigidbody;

    protected virtual void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();

        if (!_isGranade)
        {
            Destroy(gameObject, _lifeTime);
        }
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

    protected virtual void OnTriggerEnter(Collider other)
    {
        if (!_isGranade)
        {
            if (other.TryGetComponent(out Destructable destructable))
            {
                destructable.TakeDamage(_damage);
                Destroy(gameObject);
            }
        }
        else
        {
            if (other.TryGetComponent<Player>(out Player player)) return;

            if (other.TryGetComponent(out Destructable destructable))
                ActivateGranade();
        }
    }

    protected virtual void ActivateGranade()
    {

    }
}