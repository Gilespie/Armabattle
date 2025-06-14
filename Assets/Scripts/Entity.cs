using UnityEngine;

public abstract class Entity : Destructable
{
    [SerializeField] protected float _walkSpeed = 5f;
    protected float _currentSpeed = 0;
    protected Rigidbody _rigidbody;

    protected override void Awake()
    {
        base.Awake();
        _currentSpeed = _walkSpeed;
        _rigidbody = GetComponent<Rigidbody>();
    }

    protected virtual void FixedUpdate()
    {
        
    }

    public virtual void MoveEntity(Vector3 dir)
    {

    }
}