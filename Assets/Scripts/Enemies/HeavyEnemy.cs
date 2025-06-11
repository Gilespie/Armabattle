
public class HeavyEnemy : Enemy
{
    private void Start()
    {
        // _speed = 6f;
        // _damage = 20f;
        // _maxHealth = 100f;
        base.Awake();
    }

    public override void Shoot()
    {
        return
    }

    public override void DestroyEntity()
    {
        Destroy(gameObject);
    }
}