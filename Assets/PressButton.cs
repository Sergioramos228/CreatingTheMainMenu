using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PressButton : MonoBehaviour
{
    [SerializeField] private GameObject _buttonPlay;
    [SerializeField] private GameObject _buttonAboutAuthors;
    private Image _image;
    private TMP_Text _text;
    private Animator _animator;

    public void ChangeText()
    {
        if (TryGetComponent(out _text))
            _text.text = "Вы в игре!";
    }

    public void ChangeColor()
    {
        if (_buttonPlay.TryGetComponent(out _image))
            _image.color = Color.white;
    }

    public void Animate()
    {
        if (_buttonAboutAuthors.TryGetComponent(out _animator))
            _animator.SetTrigger("Animate");
    }

    public void Exit()
    {
        
    }
}
