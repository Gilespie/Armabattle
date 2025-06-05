using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float _lifeTime = 5f;
    [SerializeField] private float _damage = 15f;
    [SerializeField] private float _speed = 30f;
    private Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();    
    }

    private void Start()
    {
        Destroy(gameObject, _lifeTime);
    }

    private void FixedUpdate()
    {
        Vector3 dir = transform.forward.normalized;

        _rigidbody.MovePosition(transform.position + dir * _speed * Time.fixedDeltaTime);
    }

    public void DelayToDestroy()
    {
        Destroy(gameObject, _lifeTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.TryGetComponent(out Destructable destructable))
        {
            destructable.TakeDamage(_damage);
            Destroy(gameObject);
        }
    }
}