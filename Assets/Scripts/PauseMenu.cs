using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject _pausePanel;
    private SetTimescale _timescale;

    private void Start()
    {
        _timescale = GameManager.Instance.Timescale;
        HidePanel();    
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void LoadScene(string name)
    {
        _timescale.ChangeTimescale(1f);
        SceneManager.LoadScene(name);
    }

    public void HidePanel()
    {
        _timescale.ChangeTimescale(1f);
        _pausePanel.SetActive(false);
    }

    public void ShowPanel()
    {
        _timescale.ChangeTimescale(0f);
        _pausePanel.SetActive(true);
        GameManager.Instance.CursorBehaviour.ChangeState(true, CursorLockMode.Confined);
    }
}
