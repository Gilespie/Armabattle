using UnityEngine;

public class EnemySpawner : GenericSpawner<Enemy>
{
    protected virtual void OnSpawned(Enemy enemy)
    {
        if (enemy is IInitializableEnemy initEnemy)
        {       
            initEnemy.Initialize(GameManager.Instance.Player.transform, enemy.Damage, enemy.Score);
        }
    }
}
