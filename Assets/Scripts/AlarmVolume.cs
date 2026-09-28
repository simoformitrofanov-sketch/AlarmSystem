using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AlarmVolume : MonoBehaviour
{
    [SerializeField] private float _maxVolume = 1f;
    [SerializeField] private float _fadeSpeed = 0.5f;

    private AudioSource _audio;
    private Coroutine _fadeRoutine;

    private void Awake()
    {
        _audio = GetComponent<AudioSource>();
    }

    private void OnDisable()
    {
        if (_fadeRoutine != null)
        {
            StopCoroutine(_fadeRoutine);
            _fadeRoutine = null;
        }
    }

    public void TurnOn()
    {
        StartFade(_maxVolume);
    }

    public void TurnOff()
    {
        StartFade(0f);
    }

    private void StartFade(float targetVolume)
    {
        if (_fadeRoutine != null)
            StopCoroutine(_fadeRoutine);

        _fadeRoutine = StartCoroutine(FadeVolume(targetVolume));
    }

    private IEnumerator FadeVolume(float targetVolume)
    {
        while (enabled && _audio.volume != targetVolume)
        {
            _audio.volume = Mathf.MoveTowards(_audio.volume, targetVolume, _fadeSpeed * Time.deltaTime);
            yield return null;
        }

        _audio.volume = targetVolume;
        _fadeRoutine = null;
    }
}