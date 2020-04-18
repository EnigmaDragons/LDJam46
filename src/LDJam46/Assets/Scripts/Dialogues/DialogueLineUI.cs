using System;
using TMPro;
using UnityEngine;

public class DialogueLineUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textBox;
    [SerializeField] private FloatReference secondsPerCharacter;

    private string _text;
    private float _t;

    public bool IsRevealed => _t > _text.Length * secondsPerCharacter;
    public void Reveal() => _t = _text.Length * secondsPerCharacter;

    public void Display(string text)
    {
        _text = text;
        _t = 0;
    }

    private void Update()
    {
        _t += Time.deltaTime;
        textBox.text = _text.Substring(0, (int) Math.Min(_text.Length, Math.Floor(_t / secondsPerCharacter)));
    }
}
