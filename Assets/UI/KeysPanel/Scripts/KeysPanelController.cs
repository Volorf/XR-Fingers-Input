using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeysPanelController : MonoBehaviour
{
    [SerializeField] private GameObject key;
    [SerializeField] private float keyXOffset;
    [SerializeField] private float keyWidth;

    private List<KeyController> _keys = new List<KeyController>();
    private List<FingerTypeValuePair> _pairs;
    
    public void InitKeys(List<FingerTypeValuePair> pairs)
    {
        _pairs = pairs;
        
        for (int i = 0; i < pairs.Count; i++)
        {
            Vector3 p = new Vector3(i * (keyWidth + keyXOffset), 0f, 0f);
            GameObject k = Instantiate(key, Vector3.zero, Quaternion.identity);
            k.transform.SetParent(transform);
            k.transform.localPosition = p;
            KeyController kc = k.GetComponent<KeyController>();
            if (kc) kc.SetLetter(_pairs[i].value);
            _keys.Add(kc);
            
        }
    }

    public void HightlightKey(FingerTipType t)
    {
        KeyController k = _keys[GetIndexForKey(t)];
        if(k) k.StartHover();
    }

    private int GetIndexForKey(FingerTipType ft)
    {
        int ind = 0;
        for (int i = 0; i < _pairs.Count; i++)
        {
            if (_pairs[i].type == ft)
            {
                ind = i;
                break;
            }
        }

        return ind;
    }
}
