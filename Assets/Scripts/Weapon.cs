using System;
using System.Collections;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    public event Action OnAmmoChanged;

    [SerializeField] protected int _maxCapacityMagazine = 12;
    [SerializeField] protected int _currentCapacity = 0;
    [SerializeField] protected float _shootDelay = 0.1f;
    [SerializeField] protected float _delayReloadPerAmmo = 0.4f;
    [SerializeField] protected bool _shootMode;
    [SerializeField] protected bool _isMagazineEmpty = false;
    [SerializeField] protected bool _isReloading = false;
    [SerializeField] protected AudioClip _shootClip;
    [SerializeField] protected Transform _firePoint;
    [SerializeField] protected ParticleSystem _shootPrefab;
    [SerializeField] protected ParticleSystem _smokePrefab;
    [SerializeField] protected Projectile _projectile;
    [SerializeField] protected AmmoStorage _ammo;
    [SerializeField] protected AmmoType _ammoType;
    private AudioSource _audiosource;
    private float _timer = 0;
    public AmmoType GetAmmoType() => _ammoType;
    public int CurrentCapacity => _currentCapacity;

    protected virtual void Start()
    {
        _audiosource = GetComponent<AudioSource>();
        _currentCapacity = _maxCapacityMagazine;
        OnAmmoChanged?.Invoke();
    }

    private void Update()
    {
        if (_timer > 0)
        {
            _timer -= Time.deltaTime;
        }
    }

    public void ReloadAmmo()
    {
        if (_currentCapacity == _maxCapacityMagazine || _isReloading) return;

        StartCoroutine(ReloadRoutine());
    }

    public virtual void Shoot()
    {
        if(_isMagazineEmpty || _isReloading) return;
        if (_timer > 0) return;

        Instantiate(_projectile, _firePoint.position, _firePoint.rotation);
        ReduceAmmo();

        PlaySound();
        PlayParticle();

        _timer = _shootDelay;
    }

    protected virtual void PlaySound()
    {
        _audiosource.PlayOneShot(_shootClip);
    }

    protected virtual void PlayParticle()
    {

    }

    protected virtual void ReduceAmmo()
    {
        if (_isMagazineEmpty) return;

        _currentCapacity--;

        OnAmmoChanged?.Invoke();

        if (_currentCapacity <= 0)
        {
            _isMagazineEmpty = true;
        }
    }

    protected IEnumerator ReloadRoutine()
    {
        _isReloading = true;

        while (_currentCapacity < _maxCapacityMagazine)
        {
            if (_ammo.TryUseAmmo(_ammoType))
            {
                _currentCapacity++;

                OnAmmoChanged?.Invoke();

                _isMagazineEmpty = false;
            }
            else
            {
                break;
            }

            yield return new WaitForSeconds(_delayReloadPerAmmo);

            yield return null;
        }

        _isReloading = false;
        
        yield return null;
    }
}