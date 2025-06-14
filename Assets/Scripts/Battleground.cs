using System.Collections;
using UnityEngine;

public class Battleground : MonoBehaviour
{
    [SerializeField] private Rigidbody[] _parts;
    [SerializeField] private MeshRenderer _mesh;
    [SerializeField] private Color _idleColor;
    [SerializeField] private Color _fallColor;
    [SerializeField] private int _loopCount = 8;
    [SerializeField] private float _moveTime = 2f;
    [SerializeField] private float _fallDelayTime = 0.8f;
    [SerializeField] private float _returnDelayTime = 2f;
    private Collider _collider;
    private int _randomIndex = 0;
    private Vector3[] _defaultPositions;
    private Rigidbody[] _selectedParts;
    private bool _isMoving = false;
    

    private void Awake()
    {
        _collider = GetComponent<Collider>();
        _selectedParts = new Rigidbody[_loopCount];
        _defaultPositions = new Vector3[_selectedParts.Length];
    }

    private void OnEnable()
    {
        Timer.OnFallParts += OnActivateRandomKinematic;
    }

    private void Start()
    {
        HideParts();
    }

    private void OnDisable()
    {
        Timer.OnFallParts -= OnActivateRandomKinematic;
    }

    public void OnActivateRandomKinematic()
    {
        HideMesh();
        ActiveParts();

        StartCoroutine(FallRoutine());
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

    private void SaveDefaultPositions()
    {
        for(int i = 0; i < _defaultPositions.Length; i++)
        {
            _defaultPositions[i] = _selectedParts[i].transform.position;
        }
    }

    private IEnumerator LoadPositions()
    {
        for (int i = 0; i < _defaultPositions.Length; i++)
        {
            float elapsedTime = 0f;

            while (elapsedTime < _moveTime)
            {
                float t = elapsedTime / _moveTime;

                elapsedTime += Time.deltaTime;
                
                _selectedParts[i].transform.position = Vector3.Lerp(_selectedParts[i].transform.position, _defaultPositions[i], t);

                yield return null;
            }

            _selectedParts[i].transform.position = _defaultPositions[i];
        }

        yield return null;
    }

    private void SelectPart()
    {
        for (int i = 0; i < _loopCount; i++)
        {
            _randomIndex = UnityEngine.Random.Range(0, _parts.Length);
            _selectedParts[i] = _parts[_randomIndex];
        }
    }

    private void ChangeColor(Color color)
    {
        for(int i = 0; i < _selectedParts.Length;i++)
        {
            MeshRenderer mat = _selectedParts[i].gameObject.GetComponent<MeshRenderer>();
            mat.material.color = color;
        }
    }

    private void DeactivateKinematic()
    {
        for (int i = 0; i < _selectedParts.Length; i++)
        {
            _selectedParts[i].isKinematic = false;
        }
    }

    private void ActivateeKinematic()
    {
        for (int i = 0; i < _selectedParts.Length; i++)
        {
            _selectedParts[i].isKinematic = true;
        }
    }

    private IEnumerator FallRoutine()
    {
        SelectPart();
        SaveDefaultPositions();
        ChangeColor(_fallColor);

        yield return new WaitForSeconds(_fallDelayTime);

        DeactivateKinematic();

        yield return new WaitForSeconds(_returnDelayTime);

        ActivateeKinematic();
        ChangeColor(_idleColor);
        StartCoroutine(LoadPositions());
        
        yield return null;
    }
}