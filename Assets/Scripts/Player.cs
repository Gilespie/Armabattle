using UnityEngine;

public class Player : Entity
{
    public delegate void PlayerDelegate();
    public PlayerDelegate _playerDelegate;

    [SerializeField] private float _jumpForce = 5f;
    [SerializeField] private float _sprintSpeed = 15f;

    [Header("Weapons")]
    [SerializeField] private Weapon _pistol;
    [SerializeField] private Weapon _rifle;
    [SerializeField] private Weapon _granadeLauncher;

    private Weapon _currentWeapon;
    public Weapon CurrentWeapon => _currentWeapon;

    [SerializeField] private PauseMenu _pause;
    [SerializeField] private Raycasting _raycasting;

    private bool _isGround = false;
    private bool _isJumped = false;
    private InputController _inputController;

    public float SprintSpeed => _sprintSpeed;
    public float WalkSpeed => _walkSpeed;
    public bool IsGround => _isGround;

    public bool IsJumped { get { return _isJumped; } set { _isJumped = value; } }

    private int _currentPistolIndex = 0;


    protected override void Awake()
    {
        base.Awake();

        SelectPistol();
        _inputController = new InputController(this, _pause);
        ChangeSpeed(WalkSpeed);
    }

    protected override void Start()
    {
        base.Start();

        _playerDelegate = MoveEntity;
    }

    private void Update()
    {
        _inputController.ArtificialUpdate();
        _isGround = _raycasting.IsGrounded();
        _playerDelegate = MoveEntity;
    }

    protected void FixedUpdate()
    {
        _inputController.ArtificialFixedUpdate();
        _playerDelegate = MoveEntity;
    }

    public void SelectPistol()
    {
        SetWeapon(_pistol);
    }

    public void SelectRifle()
    {
        SetWeapon(_rifle);
    }

    public void SelectGrenade()
    {
        SetWeapon(_granadeLauncher);
    }

    private void SetWeapon(Weapon weapon)
    {

        _pistol.gameObject.SetActive(false);
        _rifle.gameObject.SetActive(false);
        _granadeLauncher.gameObject.SetActive(false);

        weapon.gameObject.SetActive(true);
        _currentWeapon = weapon;
    }

    public void ChangeSpeed(float speed)
    {
        _currentSpeed = speed;
    }

    public void Jump()
    {
         _rigidbody.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
        _isJumped = false;
    }

    public override void MoveEntity(Vector3 dir)
    {
        Vector3 move = (transform.right * dir.x + transform.forward * dir.z).normalized;
        _rigidbody.MovePosition(transform.position + move * _currentSpeed * Time.fixedDeltaTime);
    }
}