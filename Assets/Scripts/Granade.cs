using UnityEngine;

public class Granade : Weapon
{
    public override void Shoot()
    {
        if (_isMagazineEmpty || _isReloading) return;
        if (_timer > 0) return;

        Instantiate(_projectile, _firePoint.position, _firePoint.rotation);
        
        ReduceAmmo();
        PlaySound();
        PlayParticle();

        _timer = _shootDelay;
    }

    protected override void PlayParticle()
    {
        if (_shootPrefab != null)
        {
            Instantiate(_shootPrefab, _firePoint.position, _firePoint.rotation);
        }
    }
} 