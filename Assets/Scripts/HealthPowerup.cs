using UnityEngine;

public class HealthPowerup : Powerups
{
    protected override void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.TryGetComponent(out Player player) != false)
        {
            player.RestoreHealth(_value);
        }
    }
}