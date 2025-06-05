using UnityEngine;

public class AmmoPowerup : Powerups
{
    protected override void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.TryGetComponent(out Ammo ammo) != false)
        {
            ammo.IncrementAmmo((int)_value);
        }
    }
}