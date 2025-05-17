using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    [SerializeField] protected int _maxCapacityMagazine = 12;
    [SerializeField] protected int _currentCapacity = 0;
    [SerializeField] protected float _shootDelay = 0.1f;
    [SerializeField] protected bool _shootMode;
    [SerializeField] protected bool _isMagazineEmpty = false;
    [SerializeField] protected AudioClip _shootClip;
    [SerializeField] protected ParticleSystem _shootPrefab;
    [SerializeField] protected ParticleSystem _smokePrefab;
    [SerializeField] protected Projectile _projectile;
    [SerializeField] protected Ammo _ammo;

    public int GetCapacity()
    {
        return _currentCapacity;
    }

    public void ReloadAmmo()
    {

    }

    protected virtual void Shoot()
    {

    }

    protected virtual void PlaySound()
    {

    }

    protected virtual void PlayParticle()
    {

    }

    protected virtual void ReduceAmmo()
    {

    }
}