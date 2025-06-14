using UnityEngine;

public class HeaveEnemy : Enemy, IInitializableEnemy
{
    protected override void Start()
    {
        _walkSpeed = 2f;
        _maxHealth = 100f;
        _damage = 20f;
        _score = 20;

        base.Start();
    }

}
