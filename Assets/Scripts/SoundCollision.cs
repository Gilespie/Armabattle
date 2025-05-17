using UnityEngine;

public class SoundCollision : MonoBehaviour
{
    [SerializeField] private AudioClip[] _clips;
    [SerializeField] private float _volumeMultiplier = 0.2f;
    private int _randomIndex = 0;
    private AudioSource _audiosource;

    private void Initialize()
    {
        
    }
}