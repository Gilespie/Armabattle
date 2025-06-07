using UnityEngine;

public class Gravity : MonoBehaviour
{
    [SerializeField] private float _gravity = -18f;
    void Start()
    {
        Physics.gravity = new Vector3(0, _gravity, 0);
    }
}