using UnityEngine;

public abstract class Enemy : Entity
{
    [Header("Enemy Settings")]
    [SerializeField] protected float _damage = 10f;
    protected Transform _target;

    protected override void Start()
    {
        base.Start();
        if (_target == null)
            _target = GameManager.Instance.Player.transform;
    }

    protected override void FixedUpdate()
    {
        if (_target != null)
            MoveEntity(_target.position);
    }

    public override void MoveEntity(Vector3 dir)
    {
        Vector3 targetPos = (dir - _rigidbody.position).normalized;
        _rigidbody.MovePosition(_rigidbody.position + targetPos * _currentSpeed * Time.fixedDeltaTime);
    }

    protected virtual void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Destructable destructable) && destructable.GetID() != 0)
        {
            destructable.TakeDamage(_damage);
            Destroy(gameObject);
        }
    }
}
