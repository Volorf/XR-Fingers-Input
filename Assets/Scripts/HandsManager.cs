using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Volorf.VRNotifications;

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
    private List<OVRBone> _rightHandBones = new List<OVRBone>();
    private List<OVRBone> _leftHandBones = new List<OVRBone>();
    
    [Space(24)]
    [Header("Left Hand")]
    [Space(8)]
    public OVRSkeleton leftHandSkeleton;
    public FingerTipPosition LeftHandThumbTipPosition;
    public FingerTipPosition LeftHandIndexTipPosition;
    public FingerTipPosition LeftHandMiddleTipPosition;
    public FingerTipPosition LeftHandRingTipPosition;
    public FingerTipPosition LeftHandPinkyTipPosition;

    private FingerTip _activeFingerTip;
    private List<FingerTip> _allFingerTips = new List<FingerTip>();

    private void Start()
    {
        // _rightHandBones = new List<OVRBone>(rightHandSkeleton.Bones);
        // _leftHandBones = new List<OVRBone>(leftHandSkeleton.Bones);

        GameObject[] fingerTipsGo = GameObject.FindGameObjectsWithTag("FingerTip");
        foreach (var finger in fingerTipsGo)
        {
            if (finger.TryGetComponent(out FingerTip ft))
            {
                _allFingerTips.Add(ft);
            }
        }
        
        Debug.LogWarning("Count:" + _allFingerTips.Count);

    }
    
    
    void Update()
    {

        foreach (var fingerTip in _allFingerTips)
        {
            fingerTip.SetColliderTriggerOff();
        }

        // RIGHT HAND

        List<OVRBone> rhb = new List<OVRBone>(rightHandSkeleton.Bones);
        
        foreach (var bone in rhb)
        {
            switch (bone.Id)
            {
                // Thumb Tip
                case OVRSkeleton.BoneId.Hand_ThumbTip:
                {
                    RightHandThumbTipPosition.Invoke(bone.Transform.position);
                    break;
                }
                // Index Tip
                case OVRSkeleton.BoneId.Hand_IndexTip:
                {
                    RightHandIndexTipPosition.Invoke(bone.Transform.position);
                    break;
                }
                // Middle Tip
                case OVRSkeleton.BoneId.Hand_MiddleTip:
                    RightHandMiddleTipPosition.Invoke(bone.Transform.position);
                    break;
                // Ring Tip
                case OVRSkeleton.BoneId.Hand_RingTip:
                    RightHandRingTipPosition.Invoke(bone.Transform.position);
                    break;
                // Pinky Tip
                case OVRSkeleton.BoneId.Hand_PinkyTip:
                    RightHandPinkyTipPosition.Invoke(bone.Transform.position);
                    break;
            }

            float distanceScore = 0f;
            
            foreach (var fingerTip in _allFingerTips)
            {
                float fingerTipDistanceScore = fingerTip.GetSumDistance();
                if (fingerTipDistanceScore >= distanceScore)
                {
                    _activeFingerTip = fingerTip;
                    distanceScore = fingerTipDistanceScore;
                }
            }
            _activeFingerTip.SetColliderTriggerOn();
        }
        
        // LEFT HAND
        
        List<OVRBone> lhb = new List<OVRBone>(leftHandSkeleton.Bones);
        
        foreach (var bone in lhb)
        {
            switch (bone.Id)
            {
                // Thumb Tip
                case OVRSkeleton.BoneId.Hand_ThumbTip:
                {
                    LeftHandThumbTipPosition.Invoke(leftHandSkeleton.Bones[(int)OVRSkeleton.BoneId.Hand_ThumbTip].Transform.position);
                    break;
                }
                // Index Tip
                case OVRSkeleton.BoneId.Hand_IndexTip:
                {
                    LeftHandIndexTipPosition.Invoke(bone.Transform.position);
                    break;
                }
                // Middle Tip
                case OVRSkeleton.BoneId.Hand_MiddleTip:
                    LeftHandMiddleTipPosition.Invoke(bone.Transform.position);
                    break;
                // Ring Tip
                case OVRSkeleton.BoneId.Hand_RingTip:
                    LeftHandRingTipPosition.Invoke(bone.Transform.position);
                    break;
                // Pinky Tip
                case OVRSkeleton.BoneId.Hand_PinkyTip:
                    LeftHandPinkyTipPosition.Invoke(bone.Transform.position);
                    break;
            }
        }
    }
}
