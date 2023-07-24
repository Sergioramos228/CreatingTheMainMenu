using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ChangeHealthBar : MonoBehaviour
{
    [SerializeField] private float _maxValue;
    [SerializeField] private TMP_Text _text;
    
    private float _speed = 2;
    private float _targetValue;
    private Slider _slider;
    private float _changingTime = 0.1f;
    private Coroutine _heal;
    private Coroutine _damage;

    private void Start()
    {
        if (TryGetComponent(out _slider))
        {
            _slider.maxValue = _maxValue;
            _targetValue = _slider.value - 10;
            _text.text = $"{_slider.value} / {_slider.maxValue}";
        }
    }

    public void Damage()
    {
        _heal = StartCoroutine(DecreaseHealth());
    }

    public void Heal()
    {
        _damage = StartCoroutine(IncreaseHealth());
    }

    private void StopHealCoroutine()
    {
        if (_heal != null)
            StopCoroutine(_heal);
    }

    private void StopDamageCoroutine()
    {
        if (_heal != null)
            StopCoroutine(_damage);
    }

    private IEnumerator IncreaseHealth()
    {
        yield return null;
        WaitForSeconds waitForSeconds = new(_changingTime);
        float targetHealth = _slider.value + 10;

        while (_slider.value < targetHealth)
        {
            _slider.value = Mathf.MoveTowards(_slider.value, targetHealth, _speed * Time.deltaTime);
            _text.text = $"{_slider.value} / {_slider.maxValue}";
            yield return waitForSeconds;
        }

        StopHealCoroutine();
    }

    private IEnumerator DecreaseHealth()
    {
        yield return null;
        WaitForSeconds waitForSeconds = new(_changingTime);
        float targetHealth = _slider.value - 10;

        while (_slider.value > targetHealth)
        {
            _slider.value--;
            _text.text = $"{_slider.value} / {_slider.maxValue}";
            yield return waitForSeconds;
        }

        StopDamageCoroutine();
    }
}
