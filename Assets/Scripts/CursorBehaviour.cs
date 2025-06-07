using UnityEngine;

public class CursorBehaviour : MonoBehaviour
{
    [SerializeField] private CursorLockMode _mode;
    [SerializeField] private bool _isVisible = false;

    void Start()
    {
        Cursor.visible = _isVisible;
        Cursor.lockState = _mode;
    }
}