using UnityEngine;

public class AmmoPowerup : Powerups
{
    [SerializeField] private AmmoType _ammoType;

    protected override void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out AmmoStorage storage))
        {
            storage.AddAmmo(_ammoType, (int)_value);
            Destroy(gameObject);
        }
    }
}
