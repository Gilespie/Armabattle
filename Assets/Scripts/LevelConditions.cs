using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelConditions : MonoBehaviour
{
    [SerializeField] private Timer _timer;
    [SerializeField] private Player _player;
    [SerializeField] private GameObject _winPanel;
    [SerializeField] private GameObject _loosePanel;

    public void Win()
    {
        _winPanel.SetActive(true);
    }

    public void Loose()
    {
        _loosePanel.SetActive(true);
    }

    /*public void HideAll()
    {
        _winPanel.SetActive(false);
        _loosePanel.SetActive(false);
    }*/
}