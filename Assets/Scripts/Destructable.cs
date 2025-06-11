using System;
using UnityEngine;

public abstract class Destructable : MonoBehaviour
{
    public event Action<bool> OnDead;
    [SerializeField] protected int _id = 0;
    [SerializeField] protected float _maxHealth = 100;
    protected bool _isAlive = true;
    protected float _currentHealth = 0;
    protected Collider _collider;
    protected Rigidbody _rigidbody;

    protected virtual void Awake()
    {
        _collider = GetComponent<Collider>();
        _rigidbody = GetComponent<Rigidbody>();
    }

    protected virtual void Start()
    {
        _currentHealth = _maxHealth;
    }

    public virtual void TakeDamage(float damage)
     {
        if (!_isAlive || damage <= 0f)
            return;

        _currentHealth = Mathf.Clamp(_currentHealth - damage, 0, _maxHealth);

        if (_currentHealth <= 0f)
        {
            _isAlive = false;
            DestroyEntity();
        }
    }

    public void RestoreHealth(float health)
    {
        if (!_isAlive || health <= 0) return;

        _currentHealth += health;

        if(_currentHealth >= _maxHealth)
        {
            _currentHealth = _maxHealth;
        }
    }

    public int GetID()
    {
        return _id;
    }

    public float GetHealth()
    {
        return _currentHealth;
    }

    public void DestroyEntity()
    {
        _isAlive = false;
        Debug.Log("Dead!");
        OnDead?.Invoke(_isAlive);
    }
}