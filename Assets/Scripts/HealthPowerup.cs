using UnityEngine;

public class HealthPowerup : Powerups
{
    protected override void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Player player) != false)
        {
            player.RestoreHealth(_value);
            Destroy(gameObject);
        }
    }
}