using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem.XR;

[Serializable]
public class FingerTipPosition: UnityEvent<Vector3> {};

public class HandsManager : MonoBehaviour
{
    [Header("Right Hand")]
    public OVRSkeleton rightHandSkeleton;
    public FingerTipPosition RightHandIndexTipPosition;
    public FingerTipPosition RightHandThumbTipPosition;
    public FingerTipPosition RightHandMiddleTipPosition;
    public FingerTipPosition RightHandRingTipPosition;
    public FingerTipPosition RightHandPinkyTipPosition;
    

    void Update()
    {
        // RIGHT HAND
        
        // Thumb Tip
        Vector3 rightHandThumbTipPosition = rightHandSkeleton.Bones[(int)OVRSkeleton.BoneId.Hand_ThumbTip].Transform.position;
        RightHandThumbTipPosition.Invoke(rightHandThumbTipPosition);
        
        // Index Tip
        Vector3 rightHandIndexTipIndexPosition = rightHandSkeleton.Bones[(int)OVRSkeleton.BoneId.Hand_IndexTip].Transform.position;
        RightHandIndexTipPosition.Invoke(rightHandIndexTipIndexPosition);
        
        // Middle Tip
        Vector3 rightHandMiddleTipIndexPosition = rightHandSkeleton.Bones[(int)OVRSkeleton.BoneId.Hand_MiddleTip].Transform.position;
        RightHandMiddleTipPosition.Invoke(rightHandMiddleTipIndexPosition);
        
        // Ring Tip
        Vector3 rightHandRingTipIndexPosition = rightHandSkeleton.Bones[(int)OVRSkeleton.BoneId.Hand_RingTip].Transform.position;
        RightHandRingTipPosition.Invoke(rightHandRingTipIndexPosition);
        
        // Pinky Tip
        Vector3 rightHandPinkyTipIndexPosition = rightHandSkeleton.Bones[(int)OVRSkeleton.BoneId.Hand_PinkyTip].Transform.position;
        RightHandPinkyTipPosition.Invoke(rightHandPinkyTipIndexPosition);
    }
}
