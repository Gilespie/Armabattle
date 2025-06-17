using UnityEngine;

public class LightEnemy : Enemy, IInitializableEnemy
{
    protected override void Start()
    {
        _walkSpeed = 4f;
        _maxHealth = 50f;
        _score = 10;
        _damage = 10f;

        base.Start();
    }

}
