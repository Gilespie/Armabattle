using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private string _sceneName = "";
    [SerializeField] private GameObject _creditsPanel;
    [SerializeField] private GameObject _mainPanel;
    [SerializeField] private AudioClip _musicClip;
    private AudioSource _audiosource;

    private void Awake()
    {
        _audiosource = GetComponent<AudioSource>();
        _audiosource.clip = _musicClip;
        _audiosource.Play();
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void LoadScene(string name)
    {
        SceneManager.LoadScene(name);
    }

    public void OpenPanel()
    {
        
    }

    public void HidePanel()
    {
        
    }
}