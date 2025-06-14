using System.Collections;
using UnityEngine;

public class GenericSpawner<T> : MonoBehaviour where T : MonoBehaviour 
{
    [Header("Main")]
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private T[] _prefabs;
    [SerializeField] private float _secondToSpawn = 1f;

    [Header("Settings for random postion spawn")]
    [SerializeField] private bool _useRandomPosition = false;
    [SerializeField] private float _zLimit = 100f;
    [SerializeField] private float _xLimit = 100f;
    private Vector3 _cubeSize;
    private Vector3 _randomPos;

    private int _randomIndex = 0;
    private Player _player;
    private bool _canSpawn = true;
    

    private void OnEnable()
    {
        if (!_useRandomPosition)
        {
            StartCoroutine(SpawnRotine());
        }
    }

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

    public void Spawn()
    {
        _randomIndex = Random.Range(0, _prefabs.Length);
        Vector3 spawnPos = Vector3.zero;

        if (_useRandomPosition)
        {
            spawnPos = new Vector3(
                Random.Range(-_xLimit / 2f, _xLimit / 2f),
                1.16f,
                Random.Range(-_zLimit / 2f, _zLimit / 2f)
            );
        }
        else if (_spawnPoints.Length > 0)
        {
            spawnPos = _spawnPoints[Random.Range(0, _spawnPoints.Length)].position;
        }
        else
        {
            spawnPos = transform.position;
        }

        Instantiate(_prefabs[_randomIndex], spawnPos, Quaternion.identity);
    }

    private IEnumerator SpawnRotine()
    {
        while (_canSpawn)
        {
            Spawn();
            yield return new WaitForSeconds(_secondToSpawn);
        }

        yield return null;
    }

    private void OnDrawGizmos()
    {
        if(_useRandomPosition)
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireCube(transform.position, new(_xLimit, 0, _zLimit));
        }
    }
}