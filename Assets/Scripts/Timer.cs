using System;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public static event Action OnFallParts;
    public static event Action OnSpawnPowerups;
    public static event Action OnFinishRound;

    [SerializeField] private float _roundDuration = 60f;
    [SerializeField] private float _secondsToEvent = 15f;
    [SerializeField] private float _secondsToSpawn = 15f;
    [SerializeField] private Battleground _battleground;

    private float _currentRoundTime = 0f;
    private float _currentSpawnTime = 0f;
    private float _currentEventTime = 0f;

    public float CurrentTime
    {
        get { return _currentRoundTime; }
        private set { _currentRoundTime = value; }
    }
    

    private void Awake()
    {
        _currentRoundTime = _roundDuration;  
        _currentEventTime = _secondsToEvent;
        _currentSpawnTime = _secondsToSpawn;
    }

    private void Update()
    {
        _currentRoundTime -= Time.deltaTime;
        _currentEventTime -= Time.deltaTime;
        _currentSpawnTime -= Time.deltaTime;

        if (_currentRoundTime <= 0f)
        {
            _currentRoundTime = 0f;
            OnFinishRound?.Invoke();
        }
        
        if (_currentEventTime <= 0f)
        {
            RestartTimer(ref _currentEventTime, _secondsToEvent);
            OnFallParts?.Invoke();
        }

        if (_currentSpawnTime <= 0f)
        {
            RestartTimer(ref _currentSpawnTime, _secondsToSpawn);
            OnSpawnPowerups?.Invoke();
        }
    }

    public void RestartTimer(ref float currentTime, float setTime)
    {
        currentTime = setTime;
    }

    public float GetTime()
    {
        return _currentRoundTime;
    }
}