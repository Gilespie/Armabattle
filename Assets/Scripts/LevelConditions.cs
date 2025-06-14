using UnityEngine;

public class LevelConditions : MonoBehaviour
{
    [SerializeField] private GameObject _winPanel;
    [SerializeField] private GameObject _loosePanel;
    private CursorBehaviour _cursor;
    private SetTimescale _timescale;

    private void OnEnable()
    {
        Timer.OnFinishRound += Win;
        Player.OnDead += Loose;
    }

    private void Awake()
    {
        _cursor = GameManager.Instance.CursorBehaviour;
        _timescale = GameManager.Instance.Timescale;
        HideAll();
    }

    private void OnDisable()
    {
        Timer.OnFinishRound -= Win;
        Player.OnDead -= Loose;
    }

    public void Win()
    {
        _winPanel.SetActive(true);
        _cursor.ChangeState(true, CursorLockMode.Confined);
        _timescale.ChangeTimescale(0f);
    }

    public void Loose()
    {
        _loosePanel.SetActive(true);
        _cursor.ChangeState(true, CursorLockMode.Confined);
        _timescale.ChangeTimescale(0f);
    }

    public void HideAll()
    {
        _winPanel.SetActive(false);
        _loosePanel.SetActive(false);
    }
}