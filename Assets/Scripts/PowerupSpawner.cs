using UnityEngine;

public class PowerupSpawner : MonoBehaviour
{
    [SerializeField] private Powerups[] _powerups;
    [SerializeField] private float _zLimitPos = 100f;
    [SerializeField] private float _xLimitPos = 100f;
    private Vector3 _cubeSize;
    private Vector3 _randomPos;

    private int _randomIndex = 0;

    private void OnEnable()
    {
        Timer.OnSpawnPowerups += SpawnPowerup;
    }

    private void OnDisable()
    {
        Timer.OnSpawnPowerups -= SpawnPowerup;
    }

    public void SpawnPowerup()
    {
        _randomIndex = Random.Range(0, _powerups.Length);
        _randomPos = new(Random.Range(-_xLimitPos/2, _xLimitPos/2), 1.16f, Random.Range(-_zLimitPos/2, _zLimitPos/2));

        Instantiate(_powerups[_randomIndex].gameObject, _randomPos, Quaternion.identity); 
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        _cubeSize = new(_xLimitPos, 0, _zLimitPos);
        Gizmos.DrawWireCube(transform.position, _cubeSize);
    }
}