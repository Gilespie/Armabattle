using UnityEngine;

public class KillZone : MonoBehaviour
{
    [SerializeField] private float _damage = 500f;

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out Destructable destruct))
        {
            destruct.TakeDamage(_damage);
            Destroy(destruct.gameObject);
        }
    }
}