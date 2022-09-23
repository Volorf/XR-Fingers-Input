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
    [SerializeField] private Color normalColor;
    [SerializeField] private Color highlightColor;
    [SerializeField] private TextMeshProUGUI label;
    [SerializeField] private float animDur;

    private Vector3 _hiddenScale = Vector3.zero;
    private Vector3 _shownScale = Vector3.one;

    private void OnEnable()
    {
        // transform.localScale = _hiddenScale;
    }

    [ContextMenu("Start Hover")]
    public void StartHover()
    {
        transform.DOScale(_shownScale, animDur);
        bg.DOColor(highlightColor, animDur);
    }
    
    [ContextMenu("End Hover")]
    public void EndHover()
    {
        bg.DOColor(normalColor, animDur);
        transform.DOScale(_hiddenScale, animDur).OnComplete(() => { transform.gameObject.SetActive(false);});
    }

    public void SetLetter(string s)
    {
        label.text = s;
    }
}
