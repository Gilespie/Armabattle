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
    private Vector3 _direction;

    public InputController(Player player, PauseMenu pauseMenu)
    {
        _player = player;
        _pauseMenu = pauseMenu;
    }

    public void ArtificialUpdate()
    {
        _direction.x = Input.GetAxis("Horizontal");
        _direction.z = Input.GetAxis("Vertical");
        _direction.Normalize();

        if (Input.GetKeyDown(_jump) && _player.IsGround)
        {
            _player.IsJumped = true;
        }

        if (Input.GetKeyDown(_shoot))
        {
            _player.CurrentWeapon.Shoot();
        }

        if (Input.GetKeyDown(_reloadWeapon))
        {
            _player.CurrentWeapon.ReloadAmmo();
        }

        if (Input.GetKeyDown(_pistol))
        {
            _player.SelectPistol();
        }

        if (Input.GetKeyDown(_rifle))
        {
            _player.SelectRifle();
        }

        if (Input.GetKeyDown(_granade))
        {
            _player.SelectGrenade();
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
            _player.IsJumped=false;
        }

        if(_direction.sqrMagnitude != 0.0f)
        {
            _player.MoveEntity(_direction);
        }
    }
}
