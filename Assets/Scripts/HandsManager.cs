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
    [Space(8)]
    public OVRSkeleton rightHandSkeleton;
    public FingerTipPosition RightHandThumbTipPosition;
    public FingerTipPosition RightHandIndexTipPosition;
    public FingerTipPosition RightHandMiddleTipPosition;
    public FingerTipPosition RightHandRingTipPosition;
    public FingerTipPosition RightHandPinkyTipPosition;
    private List<OVRBone> _rightHandBones;
    
    [Space(24)]
    [Header("Left Hand")]
    [Space(8)]
    public OVRSkeleton leftHandSkeleton;
    public FingerTipPosition LeftHandThumbTipPosition;
    public FingerTipPosition LeftHandIndexTipPosition;
    public FingerTipPosition LeftHandMiddleTipPosition;
    public FingerTipPosition LeftHandRingTipPosition;
    public FingerTipPosition LeftHandPinkyTipPosition;

    private void Start()
    {
        // _rightHandBones = new List<OVRBone>(rightHandSkeleton.Bones);
    }

    void Update()
    {
        // RIGHT HAND
        // foreach (var bone in _rightHandBones)
        // {
        //     // Thumb Tip
        //     if (bone.Id == OVRSkeleton.BoneId.Hand_ThumbTip)
        //     {
        //         Transform rightHandThumbTipTransform = rightHandSkeleton.Bones[(int)OVRSkeleton.BoneId.Hand_ThumbTip].Transform;
        //         RightHandThumbTipPosition.Invoke(rightHandThumbTipTransform.position);
        //     }
        // }
        


        // // Index Tip
        // Transform rightHandIndexTipTransform = rightHandSkeleton.Bones[(int)OVRSkeleton.BoneId.Hand_IndexTip].Transform;
        // if (rightHandIndexTipTransform != null)
        // {
        //     RightHandIndexTipPosition.Invoke(rightHandIndexTipTransform.position);
        // }
        //
        // // // Middle Tip
        // Transform rightHandMiddleTipTransform = rightHandSkeleton.Bones[(int)OVRSkeleton.BoneId.Hand_MiddleTip].Transform;
        // if (rightHandMiddleTipTransform != null)
        // {
        //     RightHandMiddleTipPosition.Invoke(rightHandMiddleTipTransform.position);
        // }
        //
        // // // Ring Tip
        // Transform rightHandRingTipTransform = rightHandSkeleton.Bones[(int)OVRSkeleton.BoneId.Hand_RingTip].Transform;
        // if (rightHandRingTipTransform != null)
        // {
        //     RightHandRingTipPosition.Invoke(rightHandRingTipTransform.position);
        // }
        //
        // // // Pinky Tip
        // Transform rightHandPinkyTipTransform = rightHandSkeleton.Bones[(int)OVRSkeleton.BoneId.Hand_PinkyTip].Transform;
        // if (rightHandPinkyTipTransform != null)
        // {
        //     RightHandPinkyTipPosition.Invoke(rightHandPinkyTipTransform.position);
        // }
        
        
        
        
        // LEFT HAND
        
        // Thumb Tip
        // Transform leftHandThumbTipTransform = leftHandSkeleton.Bones[(int)OVRSkeleton.BoneId.Hand_ThumbTip].Transform;
        // if (leftHandThumbTipTransform != null)
        // {
        //     LeftHandThumbTipPosition.Invoke(leftHandThumbTipTransform.position);
        // }
        //
        // // // Index Tip
        // Transform leftHandIndexTipTransform = leftHandSkeleton.Bones[(int)OVRSkeleton.BoneId.Hand_IndexTip].Transform;
        // if (leftHandIndexTipTransform != null)
        // {
        //     LeftHandIndexTipPosition.Invoke(leftHandIndexTipTransform.position);
        // }
        //
        // // // Middle Tip
        // Transform leftHandMiddleTipTransform = leftHandSkeleton.Bones[(int)OVRSkeleton.BoneId.Hand_MiddleTip].Transform;
        // if (leftHandMiddleTipTransform != null)
        // {
        //     LeftHandMiddleTipPosition.Invoke(leftHandMiddleTipTransform.position);
        // }
        //
        // // // Ring Tip
        // Transform leftHandRingTipTransform = leftHandSkeleton.Bones[(int)OVRSkeleton.BoneId.Hand_RingTip].Transform;
        // if (leftHandRingTipTransform != null)
        // {
        //     LeftHandRingTipPosition.Invoke(leftHandRingTipTransform.position);
        // }
        //
        // // // Pinky Tip
        // Transform leftHandPinkyTipTransform = leftHandSkeleton.Bones[(int)OVRSkeleton.BoneId.Hand_PinkyTip].Transform;
        // if (leftHandPinkyTipTransform != null)
        // {
        //     LeftHandPinkyTipPosition.Invoke(leftHandPinkyTipTransform.position);
        // }
        
    }
}
