using UnityEngine;

public class ParticleCollision : MonoBehaviour
{
    [SerializeField] private GameObject _particlePrefab;
    [SerializeField] private float _activationForce = 3f;
    [SerializeField] private float _delayToDestroy = 15f;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision != null)
        {
            GameObject obj = Instantiate(_particlePrefab, collision.contacts[0].point, Quaternion.identity);
            Destroy(obj, _delayToDestroy);
        }
    }
}