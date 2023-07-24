using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HitPointsBar : MonoBehaviour
{
    [SerializeField] private HitPoints _target;
    [SerializeField] private Slider _view;
    [SerializeField] private TMP_Text _text;

    private float _targetValue;
    private Coroutine _viewChange;
    private WaitForSeconds _delay = new(0.001f);

    private void Awake()
    {
        _text.text = "100%";
    }
    private void OnEnable()
    {
        _target.OnChange += ChangeView;
    }
    private void OnDisable()
    {
        _target.OnChange -= ChangeView;
    }

    private void ChangeView(float newValue)
    {
        _targetValue = newValue;

        if (_viewChange == null)
            _viewChange = StartCoroutine(Changing());
    }

    private IEnumerator Changing()
    {
        yield return _delay;

        while(_view.value != _targetValue)
        {
            _view.value = Mathf.MoveTowards(_view.value, _targetValue, Time.deltaTime * 2);
            _text.text = $"{(int)(_view.value * 100)}%";
            yield return _delay;
        }

        _viewChange = null;
    }

}
