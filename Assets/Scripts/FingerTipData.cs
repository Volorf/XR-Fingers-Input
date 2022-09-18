using UnityEngine;

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

[CreateAssetMenu(fileName = "Finger Tip Data", menuName = "Create Finger Tip Data")]
public class FingerTipData : ScriptableObject
{
    public FingerTipType type;
    public string key;
}
