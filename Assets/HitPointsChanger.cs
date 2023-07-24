using UnityEngine;
using UnityEngine.UI;

public class HitPointsChanger : MonoBehaviour
{
    [SerializeField] private int _countOfChange;
    [SerializeField] private Button _button;
    [SerializeField] private HitPoints _target;

    private void ChangeHitPoints()
    {
        _target.Change(_countOfChange);
    }

    private void OnEnable()
    {
        _button.onClick.AddListener(ChangeHitPoints);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(ChangeHitPoints);
    }
}
