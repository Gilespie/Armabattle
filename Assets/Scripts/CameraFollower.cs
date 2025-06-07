using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    [SerializeField] private float _lerpRate = 3f;
    [SerializeField] private Vector3 _offset;
    [SerializeField] private Transform _player;
    [SerializeField] private float _mouseSensitivity = 100f;
    [SerializeField] private Transform _playerBody;
    private float _xRotation = 0f;

    void Start()
    {
        transform.position = _player.position + _offset;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void FixedUpdate()
    {
        Vector3 targetPos = _player.position + _offset;
        
        transform.position = Vector3.Lerp(transform.position, targetPos, _lerpRate * Time.fixedDeltaTime);
        transform.LookAt(_player);
    }
}