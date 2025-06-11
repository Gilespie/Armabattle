
public class LightEnemy : Enemy
{
    private void Start()
    {
        // _speed = 4.5f;
        // _damage = 10f;
        // _maxHealth = 50f;
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