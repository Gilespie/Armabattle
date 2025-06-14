using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    [SerializeField] private Transform _player;

    [Header("Camera")]
    [SerializeField, Range(10f, 5000f)] private float _mouseSensitivity = 500f;
    [SerializeField, Range(1f, 10f)] private float _maxDistance = 4f;
    [SerializeField, Range(-90f, 0f)] private float _minRotation = -80f;
    [SerializeField, Range(0f, 90f)] private float _maxRotation = 80f;
    [SerializeField] private float _lerpRate = 3f;
    //[SerializeField] private Vector3 _offset;

    private float _mouseX, _mouseY;
    private Vector2 _mouseInput;
    public Vector2 MouseInput { get { return _mouseInput; } set { _mouseInput = value; } }
    private Camera _camera;
    private Transform _target;

    void Start()
    {
        _target = GameManager.Instance.Player.transform;
        _camera = Camera.main;

        transform.forward = _target.forward;

        _mouseX = transform.eulerAngles.y;
        _mouseY = transform.eulerAngles.x;
    }

    void Update()
    {
        UpdateCameraRotation(_mouseInput);
    }

    private void FixedUpdate()
    {
        UpdateCameraPosition();
    }

    private void UpdateCameraRotation(Vector2 input)
    {
        _mouseX += input.x * _mouseSensitivity * Time.deltaTime;
        _mouseY -= input.y * _mouseSensitivity * Time.deltaTime;

        _mouseY = Mathf.Clamp(_mouseY, _minRotation, _maxRotation);
    }

    private void UpdateCameraPosition()
    {
        Quaternion rotation = Quaternion.Euler(_mouseY, _mouseX, 0f);
        Vector3 desiredPosition = _target.position - rotation * Vector3.forward * _maxDistance;

        _camera.transform.position = Vector3.Lerp(_camera.transform.position, desiredPosition, _lerpRate * Time.deltaTime);
        _camera.transform.LookAt(_target.position);
    }

    public Vector3 GetForward()
    {
        var forward = transform.forward;
        forward.y = 0f;
        return forward.normalized;
    }

    public Vector3 GetRight()
    {
        var right = transform.right;
        right.y = 0f;
        return right.normalized;
    }
}