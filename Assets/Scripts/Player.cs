using UnityEngine;

public class Player : Entity
{
    [SerializeField] private float _jumpForce = 5f;
    [SerializeField] private Weapon _weapon;
    [SerializeField] private PauseMenu _pause;

    private void Jump()
    {
        _rb.AddForce(Vector3.up * _jumpForce);
    }
}
