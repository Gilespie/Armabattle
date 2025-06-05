using UnityEngine;

public abstract class Enemy : Entity
{
    [SerializeField] protected float _damage = 5f;
    protected Vector3 _target;
}