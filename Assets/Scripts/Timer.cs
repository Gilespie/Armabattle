using System;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public static event Action OnFallParts;
    public static event Action OnFinishRound;
    public static event Action OnEveryTick;

    [SerializeField] private float _roundDuration = 60f;
    [SerializeField] private float _secondsToEvent = 15f;
    [SerializeField] private Battleground _battleground;

    private float _currentRoundTime = 0f;
    private float _currentEventTime = 0f;
    private float _tick = 1f;

    public float CurrentTime
    {
        get { return _currentRoundTime; }
        private set { _currentRoundTime = value; }
    }
    

    private void Awake()
    {
        _currentRoundTime = _roundDuration;  
        _currentEventTime = _secondsToEvent;
    }

    private void Update()
    {
        _currentRoundTime -= Time.deltaTime;
        _currentEventTime -= Time.deltaTime;
        _tick -= Time.deltaTime;

        if (_tick <= 0f)
        {
            _tick = 1f;
            OnEveryTick?.Invoke();
        }

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
    }

    public void RestartTimer(ref float currentTime, float setTime)
    {
        currentTime = setTime;
    }
}