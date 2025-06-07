using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    [SerializeField] protected int _maxCapacityMagazine = 12;
    [SerializeField] protected int _currentCapacity = 0;
    [SerializeField] protected float _shootDelay = 0.1f;
    [SerializeField] protected bool _shootMode;
    [SerializeField] protected bool _isMagazineEmpty = false;
    [SerializeField] protected AudioClip _shootClip;
    [SerializeField] protected Transform _firePoint;
    [SerializeField] protected ParticleSystem _shootPrefab;
    [SerializeField] protected ParticleSystem _smokePrefab;
    [SerializeField] protected Projectile _projectile;
    [SerializeField] protected AmmoStorage _ammo;
    [SerializeField] protected AmmoType _ammoType;
    public AmmoType GetAmmoType() => _ammoType;


    protected virtual void Start()
    {
        _currentCapacity = _maxCapacityMagazine;
    }

    public int GetCapacity()
    {
        return _currentCapacity;
    }

    public void ReloadAmmo()
    {
        if (_currentCapacity == _maxCapacityMagazine) return;

        if (_ammo.TryUseAmmo(_ammoType))
        {
            _currentCapacity++;
            _isMagazineEmpty = false;
        }
    }

    public virtual void Shoot()
    {
        if(_isMagazineEmpty) return;
        Instantiate(_projectile, _firePoint.position, _firePoint.rotation);
        ReduceAmmo();

        PlaySound();
        PlayParticle(); 
    }

    protected virtual void PlaySound()
    {

    }

    protected virtual void PlayParticle()
    {

    }

    protected virtual void ReduceAmmo()
    {
        if (_isMagazineEmpty) return;

        _currentCapacity--;

        if (_currentCapacity <= 0)
        {
            _isMagazineEmpty = true;
        }
    }
}