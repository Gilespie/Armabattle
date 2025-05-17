using UnityEngine;

public abstract class Ammo : MonoBehaviour
{
    [SerializeField] protected int _ammoCount = 1;

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