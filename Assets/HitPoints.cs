using System;
using UnityEngine;

public class HitPoints : MonoBehaviour
{
    [SerializeField] private int _base;
    [SerializeField] private int _current;

    public event Action<float> OnChange;

    public void Change(int value)
    {
        _current += value;
        _current = Math.Clamp(_current, 0, _base);
        OnChange?.Invoke((float) _current / _base);
    }
}
