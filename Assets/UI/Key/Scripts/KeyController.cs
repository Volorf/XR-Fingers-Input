using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class KeyController : MonoBehaviour
{
    [SerializeField] private Image bg;
    [SerializeField] private Color normalColorBG;
    [SerializeField] private Color highlightColorBG;
    [SerializeField] private TextMeshProUGUI label;
    [SerializeField] private Color normalColorLabel;
    [SerializeField] private Color highlightColorLabel;
    [SerializeField] private float animDur;

    [SerializeField] private Vector3 _hiddenScale;
    [SerializeField] private Vector3 _shownScale;

    private void Start()
    {
        transform.localScale = _hiddenScale;
    }

    [ContextMenu("Start Hover")]
    public void StartHover(bool isHighlighted)
    {
        transform.DOScale(_shownScale, animDur);
        bg.color = normalColorBG;
        label.color = normalColorLabel;
        
        if (isHighlighted)
        {
            bg.color = highlightColorBG;
            label.color = highlightColorLabel;
        }
    }
    
    // [ContextMenu("End Hover")]
    public void EndHover()
    {
        transform.DOScale(_hiddenScale, animDur);
    }

    public void SetLetter(string s)
    {
        label.text = s;
    }
}
