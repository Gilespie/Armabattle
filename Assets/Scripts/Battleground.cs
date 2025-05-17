using UnityEngine;

public class Battleground : MonoBehaviour
{
    [SerializeField] private Rigidbody[] _parts;
    [SerializeField] private MeshRenderer _mesh;
    [SerializeField] private Material _material;
    [SerializeField] private Timer _timer;
    [SerializeField] private int _loopCount = 3;

    public void OnActivateRandomKinematic()
    {
        for (int i = 0; i < _loopCount; i++)
        {

        }
    }

    public void HideMesh()
    {
        _mesh.enabled = false;
    }

    public void HideParts()
    {
        for (int i = 0; i < _parts.Length; i++)
        {
            _parts[i].gameObject.SetActive(false);
        }
    }

    public void ActiveParts()
    {
        for (int i = 0; i < _parts.Length; i++)
        {
            _parts[i].gameObject.SetActive(true);
        }
    }
}