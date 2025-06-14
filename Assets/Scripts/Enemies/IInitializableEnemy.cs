using UnityEngine;

public interface IInitializableEnemy
{
    void Initialize(Transform target, float damage, int score);
}
