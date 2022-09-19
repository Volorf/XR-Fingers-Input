using System;
using System.Collections.Generic;
using System.Collections;
using Unity.VisualScripting;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

[Serializable]
public enum FingerTipType
{
    RightHandThumb,
    RightHandIndex,
    RightHandMiddle,
    RightHandRing,
    RightHandPinky,
    LeftHandThumb,
    LeftHandIndex,
    LeftHandMiddle,
    LeftHandRing,
    LeftHandPinky
}

[Serializable]
public struct FingerTypeValuePair
{
    public FingerTipType type;
    public string value;
}

[CreateAssetMenu(fileName = "Finger Tip Data", menuName = "Create Finger Tip Data")]
public class FingerTipData : ScriptableObject
{
    public FingerTipType type;
    [SerializeField] private List<FingerTypeValuePair> pairs;

    public Hashtable Values = new Hashtable();

    void OnEnable()
    {
        foreach (var item in pairs)
        {
            Values.Add(item.type, item.value);
        }
    }
}
