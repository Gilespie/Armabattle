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
         _audioSource = GetComponent<AudioSource>();

        if (_audioSource != null && _musicClip != null)
        {
            _audioSource.clip = _musicClip;
            _audioSource.loop = true;
            _audioSource.Play();
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
        if (_creditsPanel != null)
            _creditsPanel.SetActive(true);
    }

    public void HideCreditsPanel()
    {
        if (_creditsPanel != null)
            _creditsPanel.SetActive(false);
    }
}
