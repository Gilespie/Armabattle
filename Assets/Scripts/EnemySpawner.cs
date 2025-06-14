using System.Collections;
using UnityEngine;

public class EnemySpawner : GenericSpawner<Enemy>
{
    /*[SerializeField] private Transform[] _spawnPoses;
    [SerializeField] private Enemy[] _enemies;
    [SerializeField] private float _secondToSpawn = 1f;
    private int _randomIndex = 0;
    private Player _player;
    private bool _canSpawn = true;

    private void Start()
    {
        StartCoroutine(SpawnRotine());

        _player = GameManager.Instance.Player;
        Player.OnDead += ChangeState;
    }

    private void OnDisable()
    {
        Player.OnDead -= ChangeState;
    }

    private void ChangeState()
    {
        _canSpawn = false;
    }

    private IEnumerator SpawnRotine()
    {
        while(_canSpawn)
        {
            _randomIndex = Random.Range(0, _enemies.Length);

            Enemy obj = Instantiate(_enemies[_randomIndex],
                _spawnPoses[Random.Range(0, _spawnPoses.Length)].position,
                Quaternion.identity);

            yield return new WaitForSeconds(_secondToSpawn);
        }

        yield return null;
    }*/
}