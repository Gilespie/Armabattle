using UnityEngine;

public class SetTimescale : MonoBehaviour
{
    private void Awake()
    {
        GameManager.Instance.Timescale = this;
    }

    public void ChangeTimescale(float timeScale)
    {
        Time.timeScale = timeScale;
    }
}