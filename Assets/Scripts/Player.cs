using UnityEngine;

public class Player : Entity
{
    public delegate void PlayerDelegate();
    public PlayerDelegate _playerDelegate;

    [SerializeField] private float _jumpForce = 5f;
    [SerializeField] private Weapon _weapon;
    [SerializeField] private PauseMenu _pause;
    [SerializeField] private Raycasting _raycasting;
    private Vector3 _direction;
    private bool _isGround = false;
    private bool _isJumped = false;
    

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    protected override void Start()
    {
        _playerDelegate = MoveEntity;
    }

    private void Update()
    {
        _direction.x = Input.GetAxis("Horizontal");
        _direction.z = Input.GetAxis("Vertical");

        _direction.Normalize();

        _isGround = _raycasting.IsGrounded();

        if (Input.GetKeyDown(KeyCode.Space) && _isGround)
        {
            _isJumped = true;
        }
    }

    protected void FixedUpdate()
    {
        if (_isJumped)
        {
            Jump();
            _isJumped= false;
        }

        if(_direction.sqrMagnitude != 0.0f)
        _playerDelegate();
    }

    private void Jump()
    {
         _rigidbody.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
    }

    protected override void MoveEntity()
    {
        Vector3 move = (transform.right * _direction.x + transform.forward * _direction.z).normalized;
        _rigidbody.MovePosition(transform.position + move * _speed * Time.fixedDeltaTime);
    }
}