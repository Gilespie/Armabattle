using UnityEngine;

public class PowerupSpawner : MonoBehaviour
{
    [SerializeField] private Powerups[] _powerups;
    [SerializeField] private float _zLimitPos = 10f;
    [SerializeField] private float _xLimitPos = 10f;
    private int _randomIndex = 0;

    public void SpawbPowerup()
    {
        _randomIndex = Random.Range(0, _powerups.Length);

        Instantiate(_powerups[_randomIndex].gameObject); 
    }
}