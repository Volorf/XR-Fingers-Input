using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ConsoleController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI label;
    private string _message = "";

    public void AddText(string text)
    {
        _message += text;
        label.text = _message;
    }

    public void Clear() => _message = "";
}
