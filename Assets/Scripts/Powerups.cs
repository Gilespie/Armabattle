using UnityEngine;

public abstract class Powerups : MonoBehaviour
{
    protected enum TypeOfPowerup
    {
        Health,
        Ammo
    }

    [SerializeField] protected TypeOfPowerup _typeOfPowerup;
    [SerializeField] protected float _value = 5f;

    protected virtual void OnCollisionEnter(Collision collision)
    {
        
    }
}
