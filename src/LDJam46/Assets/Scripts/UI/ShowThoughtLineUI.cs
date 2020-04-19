
using System;
using TMPro;
using UnityEngine;

public class ShowThoughtLineUI : MonoBehaviour
{
    [SerializeField] private TextMeshPro textBox;
    [SerializeField] private FloatReference secondsPerCharacter;

    private string _text = "";
    private float _t;
    private Action _onFinished;

    public bool IsRevealed => _t >= _text.Length * secondsPerCharacter;
    public void Reveal() => _t = _text.Length * secondsPerCharacter;

    public void Display(string text, Action onFinished)
    {
        textBox.text = "";
        gameObject.SetActive(true);
        _onFinished = onFinished;
        _text = text;
        _t = 0;
    }

    private void Update()
    {
        if (IsRevealed)
            return;
        
        _t += Time.deltaTime;
        textBox.text = _text.Substring(0, (int) Math.Min(_text.Length, Math.Floor(_t / secondsPerCharacter)));
        if (IsRevealed)
            _onFinished();
    }
}
