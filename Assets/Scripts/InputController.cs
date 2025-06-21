using UnityEngine;

public class InputController
{
    [SerializeField] private KeyCode _jump = KeyCode.Space;
    [SerializeField] private KeyCode _pause = KeyCode.Escape;
    [SerializeField] private KeyCode _reloadWeapon = KeyCode.R;
    [SerializeField] private KeyCode _shoot = KeyCode.Mouse0;
    [SerializeField] private KeyCode _sprint = KeyCode.LeftShift;
    [SerializeField] private KeyCode _pistol = KeyCode.Alpha1;
    [SerializeField] private KeyCode _rifle = KeyCode.Alpha2;
    [SerializeField] private KeyCode _granade = KeyCode.Alpha3;

    private Player _player;
    private PauseMenu _pauseMenu;
    private CameraFollower _cameraFollower;
    private Vector3 _direction;
    private Vector2 _mouseInput;
    private float _rotationRate = 20f;

    public InputController(Player player, PauseMenu pauseMenu, CameraFollower cameraFollower)
    {
        _player = player;
        _pauseMenu = pauseMenu;
        _cameraFollower = cameraFollower;
    }

    public void ArtificialUpdate()
    {
        _direction = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")).normalized;
        _mouseInput = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
        _cameraFollower.MouseInput = _mouseInput;

        if (Input.GetKeyDown(_jump) && _player.IsGround)
        {
            _player.IsJumped = true;
        }

        if (Input.GetKey(_shoot))
        {
            _player.CurrentWeapon.Shoot();
        }

        if (Input.GetKeyDown(_reloadWeapon))
        {
            _player.CurrentWeapon.ReloadAmmo();
        }

        if (Input.GetKeyDown(_pistol))
        {
            _player.SetWeapon(TypeOfWeapon.Pistol);
        }

        if (Input.GetKeyDown(_rifle))
        {
            _player.SetWeapon(TypeOfWeapon.Rifle);
        }

        if (Input.GetKeyDown(_granade))
        {
            _player.SetWeapon(TypeOfWeapon.GranadeLauncher);
        }

        if(Input.GetKeyDown(_pause))
        {
            _pauseMenu.ShowPanel();
        }

        if (Input.GetKey(_sprint))
        {
            _player.ChangeSpeed(_player.SprintSpeed);
        }
        else
        {
            _player.ChangeSpeed(_player.WalkSpeed);
        }
    }

    public void ArtificialFixedUpdate()
    {
        if (_player.IsJumped && _player.IsGround)
        {
            _player.Jump();
            _player.IsJumped = false;
        }

        if(_direction.sqrMagnitude != 0.0f)
        {
            Vector3 moveDir = _cameraFollower.GetForward() * _direction.z + _cameraFollower.GetRight() * _direction.x;
            _player.MoveEntity(moveDir.normalized);

            Quaternion targetRotation = Quaternion.LookRotation(moveDir.normalized, Vector3.up);
            _player.transform.rotation = Quaternion.Lerp(_player.transform.rotation, targetRotation, _rotationRate * Time.fixedDeltaTime);
        }
    }
}