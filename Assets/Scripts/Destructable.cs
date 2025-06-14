using System;
using UnityEngine;

public abstract class Destructable : MonoBehaviour
{
    
    public event Action OnHealthChanged;

    [SerializeField] protected int _id = 0;

    [SerializeField] protected float _maxHealth = 100;
    public float MaxHealth => _maxHealth; 

    protected bool _isAlive = true;

    protected float _currentHealth = 0;
    public float CurrentHealth
    {
        get { return _currentHealth; }
        private set { _currentHealth = value; }
    }

    protected Collider _collider;
    
    protected virtual void Awake()
    {
        _collider = GetComponent<Collider>();
    }

    protected virtual void Start()
    {
        _currentHealth = _maxHealth;
    }

    public void TakeDamage(float damage)
    {
        if(damage <= 0) return;

        _currentHealth -= damage;
        OnHealthChanged?.Invoke();

        if (_currentHealth <= 0)
        {
            _currentHealth = 0f;
            DeactivateObject();
        }
    }

    public void RestoreHealth(float health)
    {
        if (health <= 0) return;

        _currentHealth += health;
        OnHealthChanged?.Invoke();

        if(_currentHealth >= _maxHealth)
        {
            _currentHealth = _maxHealth;
        }
    }

    public int GetID()
    {
        return _id;
    }

    protected virtual void DeactivateObject()
    {
        _isAlive = false;
        Destroy(gameObject);
    }
}