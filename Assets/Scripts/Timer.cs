using System;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public event Action OnEvent;
    [SerializeField] private float _roundDuration = 60f;
    [SerializeField] private float _secondsToEvent = 15f;
    [SerializeField] private Battleground _battleground;
    private float _currentTime = 0f;

    public float CurrentTime
    {
        get { return _currentTime; }
        private set { _currentTime = value; }
    }
    private float _eventTime = 0f;

    private void Awake()
    {
        _currentTime = _roundDuration;  
        _eventTime = _secondsToEvent;
    }

    private void Update()
    {
        _currentTime -= Time.deltaTime;
        _eventTime -= Time.deltaTime;

        if (_currentTime <= 0f)
        {
            RestartTimer();
        }
        else if (_eventTime <= 0f)
        {
            RestartEventTime();
            OnEvent?.Invoke();
        }
    }

    public void RestartTimer()
    {
        _currentTime = _roundDuration;
    }

    private void RestartEventTime()
    {
        _eventTime = _secondsToEvent;
    }

    public float GetTime()
    {
        return _currentTime;
    }
}