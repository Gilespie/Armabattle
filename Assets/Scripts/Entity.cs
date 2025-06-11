using UnityEngine;

public abstract class Entity : Destructable
{
    [SerializeField] protected float _walkSpeed = 5f;
    protected float _currentSpeed = 0;
    
    protected virtual void Start()
    {
        _currentSpeed = _walkSpeed;
    }

    public virtual void MoveEntity(Vector3 direction)
    {
        transform.position += direction.normalized * _currentSpeed * Time.deltaTime;
    }

}