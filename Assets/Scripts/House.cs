using UnityEngine;

public class House : MonoBehaviour
{
    [SerializeField] private AlarmZone _zone;
    [SerializeField] private AlarmVolume _alarm;

    private void OnEnable()
    {
        _zone.IntruderCountChanged += OnIntruderCountChanged;
    }

    private void OnDisable()
    {
        _zone.IntruderCountChanged -= OnIntruderCountChanged;
    }

    private void OnIntruderCountChanged(int count)
    {
        if (count > 0)
            _alarm.TurnOn();
        else
            _alarm.TurnOff();
    }
}