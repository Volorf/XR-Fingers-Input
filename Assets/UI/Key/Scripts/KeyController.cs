using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyController : MonoBehaviour
{
    [SerializeField] private Image bg;
    [SerializeField] private float animDur;
    [SerializeField] private AnimationCurve curve;

    [ContextMenu("Start Hover")]
    public void StartHover()
    {
        
    }
    
    [ContextMenu("End Hover")]
    public void EndHover()
    {
        
    }
}
