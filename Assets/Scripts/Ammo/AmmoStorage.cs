using UnityEngine;

public class AmmoStorage : MonoBehaviour
{
    [SerializeField] protected int _pistolAmmo = 12;
    [SerializeField] protected int _rifleAmmo = 60;
    [SerializeField] protected int _granadeAmmo = 6;
    public int PistolAmmo => _pistolAmmo;
    public int RifleAmmo => _rifleAmmo;
    public int GranadeAmmo => _granadeAmmo;

    public void IncrementAmmo(AmmoType type, int amount)
    {
        switch (type)
        {
            case AmmoType.PistolAmmo:
                _pistolAmmo += amount;
                break;
            case AmmoType.RifleAmmo:
                _rifleAmmo += amount;
                break;
            case AmmoType.GranadeAmmo:
                _granadeAmmo += amount;
                break;
        }
    }

    public bool TryUseAmmo(AmmoType type)
    {
        switch (type)
        {
            case AmmoType.PistolAmmo:
                if (_pistolAmmo > 0)
                {
                    _pistolAmmo--;
                    return true;
                }
                break;

            case AmmoType.RifleAmmo:
                if (_rifleAmmo > 0)
                {
                    _rifleAmmo--;
                    return true;
                }
                break;

            case AmmoType.GranadeAmmo:
                if (_granadeAmmo > 0)
                {
                    _granadeAmmo--;
                    return true;
                }
                break;
        }

        return false;
    }

    public int GetAmmoCount(AmmoType type)
    {
        return type switch
        {
            AmmoType.PistolAmmo => _pistolAmmo,
            AmmoType.RifleAmmo => _rifleAmmo,
            AmmoType.GranadeAmmo => _granadeAmmo,
            _ => 0
        };
    }
}
