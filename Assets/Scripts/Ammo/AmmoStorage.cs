using System.Collections.Generic;
using UnityEngine;

public class AmmoStorage : MonoBehaviour
{
    private Dictionary<AmmoType, Ammo<AmmoType>> _ammoDictionary;

    private void Awake()
    {
        _ammoDictionary = new Dictionary<AmmoType, Ammo<AmmoType>>
        {
            { AmmoType.PistolAmmo, new Ammo<AmmoType>(12) },
            { AmmoType.RifleAmmo, new Ammo<AmmoType>(60) },
            { AmmoType.GranadeAmmo, new Ammo<AmmoType>(6) }
        };
    }

    public void AddAmmo(AmmoType type, int amount)
    {
        if (_ammoDictionary.ContainsKey(type))
            _ammoDictionary[type].Add(amount);
    }

    public bool TryUseAmmo(AmmoType type)
    {
        return _ammoDictionary.ContainsKey(type) && _ammoDictionary[type].Use();
    }

    public int GetAmmoCount(AmmoType type)
    {
        return _ammoDictionary.ContainsKey(type) ? _ammoDictionary[type].Count : 0;
    }
}
