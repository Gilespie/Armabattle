using UnityEngine;

public abstract class Ammo : MonoBehaviour //old class ----delete
{
    [SerializeField] protected int _ammoCount = 30;

    public int GetAmmo()
    {
        return _ammoCount;
    }

    public void IncrementAmmo(int value)
    {
        _ammoCount += value;
    }

    public void DicrementAmmo()
    {
        _ammoCount--;
    }
}