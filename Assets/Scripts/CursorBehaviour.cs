using UnityEngine;

public class CursorBehaviour : MonoBehaviour
{
    [SerializeField] private CursorLockMode _mode;
    [SerializeField] private bool _isVisible = false;

    void Awake()
    {
        Cursor.visible = _isVisible;
        Cursor.lockState = _mode;

        GameManager.Instance.CursorBehaviour = this;
    }

    public void ChangeState(bool isVisible, CursorLockMode mode)
    {
        Cursor.visible = isVisible;
        Cursor.lockState = mode;
    }
}