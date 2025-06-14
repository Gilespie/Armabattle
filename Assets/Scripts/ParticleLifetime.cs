using UnityEngine;

public class ParticleLifetime : MonoBehaviour
{
    [SerializeField] private float _lifetime = 5f;

    void Start()
    {
        Destroy(gameObject, _lifetime);    
    }
}