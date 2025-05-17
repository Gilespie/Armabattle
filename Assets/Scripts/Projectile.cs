using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float _lifeTime = 5f;
    [SerializeField] private float _damage = 15f;
    [SerializeField] private float _speed = 30f;

    private void Start()
    {
        Destroy(gameObject, _lifeTime);
        
    }

    public void DelayToDestroy()
    {
        Destroy(gameObject, _lifeTime);
    }
}