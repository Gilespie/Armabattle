using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject _pausePanel;
    [SerializeField] private string _menuLevelName = "";

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void LoadScene(string name)
    {
        SceneManager.LoadScene(name);
    }

    public void HidePanel()
    {
        _pausePanel.SetActive(false);
    }

    public void ShowPanel()
    {
        _pausePanel.SetActive(true);
    }
}
