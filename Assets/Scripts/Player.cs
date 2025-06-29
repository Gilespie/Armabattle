using System;
using System.Collections.Generic;
using UnityEngine;

public class Player : Entity
{
    public event Action<Weapon> OnWeaponChanged;
    public static event Action OnDead;

    [SerializeField] private float _jumpForce = 5f;
    [SerializeField] private float _sprintSpeed = 15f;

    [Header("Weapons")]
    [SerializeField] private WeaponData[] _weaponData;
    [SerializeField] private TypeOfWeapon _initialWeapon;
    private Dictionary<TypeOfWeapon, Weapon> _totalWeapon = new Dictionary<TypeOfWeapon,Weapon>();

    private Weapon _currentWeapon;
    public Weapon CurrentWeapon => _currentWeapon;

    [SerializeField] private PauseMenu _pause;
    [SerializeField] private Raycasting _raycasting;
    [SerializeField] private CameraFollower _cameraFollower;

    private bool _isGround = false;
    private bool _isJumped = false;
    private InputController _inputController;

    public float SprintSpeed => _sprintSpeed;
    public float WalkSpeed => _walkSpeed;
    public bool IsGround => _isGround;

    public bool IsJumped { get { return _isJumped; } set { _isJumped = value; } }

    protected override void Awake()
    {
        base.Awake();

        foreach(var item in _weaponData)
        {
            if(!_totalWeapon.ContainsKey(item.type))
                _totalWeapon.Add(item.type, item.weapon);
        }

        _inputController = new InputController(this, _pause, _cameraFollower);
        ChangeSpeed(WalkSpeed);

        GameManager.Instance.Player = this;
    }

    protected override void Start()
    {
        base.Start();
        SetWeapon(_initialWeapon);
    }

    private void Update()
    {
        _inputController.ArtificialUpdate();
        _isGround = _raycasting.IsGrounded();
    }

    protected override void FixedUpdate()
    {
        _inputController.ArtificialFixedUpdate();
    }

    public void SetWeapon(TypeOfWeapon type)
    {
        if (!_totalWeapon.ContainsKey(type)) return;

        foreach(var item in _totalWeapon)
        {
            if (item.Value != null)
            {
                item.Value.gameObject.SetActive(false);
            }
        }

        _currentWeapon = _totalWeapon[type];
        _currentWeapon.gameObject.SetActive(true);

        OnWeaponChanged?.Invoke(_currentWeapon);
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
        _rigidbody.MovePosition(_rigidbody.position + dir * _currentSpeed * Time.fixedDeltaTime);
    }

    protected override void DeactivateObject()
    {
        base.DeactivateObject();
        OnDead.Invoke();
    }
}