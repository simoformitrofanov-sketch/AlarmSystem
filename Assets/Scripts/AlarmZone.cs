using System;
using System.Collections.Generic;
using UnityEngine;

public class AlarmZone : MonoBehaviour
{
    public event Action<int> IntruderCountChanged;

    private readonly HashSet<Intruder> _intruders = new HashSet<Intruder>();

    private void OnTriggerEnter(Collider other)
    {
        Intruder intruder = GetIntruder(other);

        if (intruder == null)
            return;

        if (_intruders.Add(intruder))
            IntruderCountChanged?.Invoke(_intruders.Count);
    }

    private void OnTriggerExit(Collider other)
    {
        Intruder intruder = GetIntruder(other);

        if (intruder == null)
            return;

        if (_intruders.Remove(intruder))
            IntruderCountChanged?.Invoke(_intruders.Count);
    }

    private void OnDestroy()
    {
        IntruderCountChanged = null;
    }

    private Intruder GetIntruder(Collider other)
    {
        Rigidbody body = other.attachedRigidbody;

        if (body == null)
            return null;

        body.TryGetComponent(out Intruder intruder);
        return intruder;
    }
}