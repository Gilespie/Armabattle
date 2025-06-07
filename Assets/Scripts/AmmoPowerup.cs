using UnityEngine;

public class AmmoPowerup : Powerups
{
    [SerializeField] private AmmoType _ammoType;

    protected override void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out AmmoStorage ammostorage))
        {
            if (ammostorage != null)
            {
                ammostorage.IncrementAmmo(_ammoType, (int)_value);
                Destroy(gameObject);
            }
        }
    }
}