using UnityEngine;

public abstract class Powerups : MonoBehaviour
{
    [SerializeField] protected float _value = 5f;

    protected virtual void OnTriggerEnter(Collider other)
    {

    }
}
