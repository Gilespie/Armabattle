using UnityEngine;

public class GranadeProjectile : Projectile
{
    [SerializeField] private float _forceX = 30f;
    [SerializeField] private float _forceY = 30f;
    [SerializeField] private float _radiusSphere = 10f;
    [SerializeField] private LayerMask _enemyLayer;
    [SerializeField] private GameObject _particlePrefab;
    private bool _shooted = false;

    private void Update()
    {
        _lifeTime -= Time.deltaTime;

        if(_lifeTime <= 0)
        {
            Instantiate(_particlePrefab, transform.position, Quaternion.identity);
            Collider[] colls = Physics.OverlapSphere(transform.position, _radiusSphere, _enemyLayer);

            for (int i = 0; i < colls.Length; i++)
            {
                Destructable destruct = colls[i].GetComponent<Destructable>();

                if (destruct != null)
                {
                    destruct.TakeDamage(_damage);
                }
            }

            Destroy(gameObject);
        }
    }

    protected override void FixedUpdate()
    {
        if(!_shooted)
        {
            MoveProject();
            _shooted = true;
        }
    }

    protected override void MoveProject()
    {
        _rigidbody.AddForce(transform.forward * _forceX + transform.up * _forceY, ForceMode.Impulse);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, _radiusSphere);
    }
}