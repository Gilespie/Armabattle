using UnityEngine;

public class Raycasting : MonoBehaviour
{
    [SerializeField] private float _groundRayDistance = 0.2f;
    [SerializeField] private LayerMask _groundLayer;
    [SerializeField] private Transform _groundRayOrigin;
    private Ray _groundRay;

    public bool IsGrounded()
    {
        _groundRay = new Ray(_groundRayOrigin.position, -transform.up);

        return Physics.Raycast(_groundRay, _groundRayDistance, _groundLayer);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawRay(_groundRayOrigin.position, Vector3.down * _groundRayDistance);
    }
}