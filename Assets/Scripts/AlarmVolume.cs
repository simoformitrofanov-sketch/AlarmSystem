using UnityEngine;
using static UnityEngine.GraphicsBuffer;

[RequireComponent(typeof(AudioSource))]
public class AlarmVolume : MonoBehaviour
{
    [SerializeField] private AlarmZone _zone;
    [SerializeField] private float _maxVolume = 1f;
    [SerializeField] private float _fadeSpeed = 0.5f;

    private AudioSource _audio;
    private float _targetVolume;

    private void Awake()
    {
        _audio = GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        _zone.IntruderCountChanged += OnIntruderCountChanged;
    }

    private void OnDisable()
    {
        _zone.IntruderCountChanged -= OnIntruderCountChanged;
    }

    private void Update()
    {
        _audio.volume = Mathf.MoveTowards(_audio.volume, _targetVolume, _fadeSpeed * Time.deltaTime);
    }

    private void OnIntruderCountChanged(int count)
    {
        _targetVolume = count > 0 ? _maxVolume : 0f;
    }
}
