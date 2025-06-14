using UnityEngine;

public abstract class Enemy : Entity
{
    [SerializeField] protected float _damage = 5f;
    [SerializeField] protected int _score = 10;
    protected Transform _target;

    //public Enemy(float speed, float health, Transform player)
    //{
    //    _walkSpeed = speed;
    //    _maxHealth = health;
    //    _target = player;
    //}

    protected override void Start()
    {
        base.Start();

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