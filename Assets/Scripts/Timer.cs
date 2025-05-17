using System;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public event Action OnEvent;
    [SerializeField] private float _roundDuration = 60f;
    [SerializeField] private float _secondsToEvent = 15f;
    [SerializeField] private Battleground _battleground;
    private float _currentTime = 0f;

    public void StartTimer()
    {

    }

    public float GetTime()
    {
        return _currentTime;
    }

    public void ActiveEvent()
    {

    }
}