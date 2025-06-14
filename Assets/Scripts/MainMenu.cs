using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngineInternal;

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

        if( _audiosource != null )
        {
            _audiosource.clip = _musicClip;
            _audiosource.Play();
        }
        
        HideCreditsPanel();
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void LoadScene(string name)
    {
        SceneManager.LoadScene(name);
    }

    public void OpenCreditsPanel()
    {
        if(_creditsPanel != null)
        _creditsPanel.SetActive(true);
    }

    public void HideCreditsPanel()
    {
        if(_creditsPanel != null)
        _creditsPanel.SetActive(false);
    }
}