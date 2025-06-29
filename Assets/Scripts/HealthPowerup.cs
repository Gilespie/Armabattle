using UnityEngine;

public class HealthPowerup : Powerups
{
    protected override void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out IRestoreLife restorable))
        {
            restorable.RestoreHealth(_value);
            Destroy(gameObject);
        }
    }
}