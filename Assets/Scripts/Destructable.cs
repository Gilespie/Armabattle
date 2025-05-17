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
    protected Rigidbody _rb;

    protected virtual void Start()
    {
        _currentHealth = _maxHealth;
    }

    public void TakeDamage(float damage)
    {
        
    }

    public void RestoreHealth(float health)
    {

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
        OnDead?.Invoke(_isAlive);
    }
}