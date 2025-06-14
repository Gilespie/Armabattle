using UnityEngine;

public class SoundCollision : MonoBehaviour
{
    [SerializeField] private AudioClip[] _clips;
    [SerializeField] private float _volumeMultiplier = 0.2f;
    private int _randomIndex = 0;
    private AudioSource _audiosource;

    private void Awake()
    {
        _audiosource = GetComponent<AudioSource>();
        _randomIndex = Random.Range(0, _clips.Length);
        _audiosource.clip = _clips[_randomIndex];
    }

    private void OnCollisionEnter(Collision collision)
    {
        _audiosource.volume = collision.impulse.magnitude * _volumeMultiplier;
        _audiosource.Play();
    }
}