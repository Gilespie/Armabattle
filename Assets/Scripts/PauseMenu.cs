using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject _pausePanel;
    //[SerializeField] private string _menuLevelName = "";

    private void Start()
    {
        HidePanel();    
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void LoadScene(string name)
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(name);
    }

    public void HidePanel()
    {
        Time.timeScale = 1.0f;
        _pausePanel.SetActive(false);
    }

    public void ShowPanel()
    {
        Time.timeScale = 0.0f;
        _pausePanel.SetActive(true);
    }
}
