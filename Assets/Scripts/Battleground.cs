using UnityEngine;

public class Battleground : MonoBehaviour
{
    [SerializeField] private Rigidbody[] _parts;
    [SerializeField] private MeshRenderer _mesh;
    [SerializeField] private Timer _timer;
    [SerializeField] private int _loopCount = 3;
    private Collider _collider;
    private int _randomIndex = 0;

    private void Awake()
    {
        _collider = GetComponent<Collider>();    
    }

    private void OnEnable()
    {
        _timer.OnEvent += OnActivateRandomKinematic;
    }

    private void Start()
    {
        HideParts();
    }

    private void OnDisable()
    {
        _timer.OnEvent += OnActivateRandomKinematic;
    }

    public void OnActivateRandomKinematic()
    {
        HideMesh();
        ActiveParts();

        for (int i = 0; i < _loopCount; i++)
        {
            _randomIndex = Random.Range(0, _parts.Length);

            _parts[_randomIndex].isKinematic = false;
        }
    }

    public void HideMesh()
    {
        _mesh.enabled = false;
        _collider.enabled = false;
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