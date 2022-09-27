using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class KeyController : MonoBehaviour
{
    [Header("Background")] 
    [SerializeField] private CanvasGroup canvasGroup;
    [SerializeField] private float normalAlpha;
    
    [Space(8)]
    [Header("Background")]
    [SerializeField] private Image bg;
    [SerializeField] private Color normalColorBG;
    [SerializeField] private Color highlightColorBG;
    
    [Space(8)]
    [Header("Label")]
    [SerializeField] private TextMeshProUGUI label;
    [SerializeField] private Color normalColorLabel;
    [SerializeField] private Color highlightColorLabel;
    [SerializeField] private float animDur;

    [SerializeField] private Vector3 _hiddenScale;
    [SerializeField] private Vector3 _shownScale;

    private void Start()
    {
        // transform.localScale = _hiddenScale;
        canvasGroup.alpha = normalAlpha;
    }

    [ContextMenu("Start Hover")]
    public void StartHover(bool isHighlighted)
    {
        transform.DOScale(_shownScale, animDur);
        bg.color = normalColorBG;
        label.color = normalColorLabel;
        canvasGroup.alpha = normalAlpha;
        
        if (isHighlighted)
        {
            bg.color = highlightColorBG;
            label.color = highlightColorLabel;
            canvasGroup.alpha = 1f;
        }
    }
    
    // [ContextMenu("End Hover")]
    public void EndHover()
    {
        // transform.DOScale(_hiddenScale, animDur);
        canvasGroup.alpha = normalAlpha;
        bg.color = normalColorBG;
        label.color = normalColorLabel;
    }

    public void SetLetter(string s)
    {
        label.text = s;
    }
}
