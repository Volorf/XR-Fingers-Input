using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowHead : MonoBehaviour
{
    [SerializeField] private float distanceFromHead;
    [SerializeField] private float downOffset;
    [SerializeField] private float followHeadSmoothKoef;
    [SerializeField] private float lookAtHeadSmoothKoef;
    private Vector3 _smoothPositionVelocity;
    private Vector3 _smoothForwardVelocity;
    private Transform _camera;
    
    void Start()
    {
        if (Camera.main != null) _camera = Camera.main.transform;
    }
    
    private Vector3 CalculateSnackBarPosition()
    {
        return _camera.position + _camera.forward * distanceFromHead + _camera.up * -1f * downOffset;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newPos = CalculateSnackBarPosition();
                transform.position = Vector3.SmoothDamp(transform.position, newPos,
                    ref _smoothPositionVelocity, followHeadSmoothKoef);

        Vector3 newForward = (_camera.position - transform.position).normalized;
        transform.forward = Vector3.SmoothDamp(transform.forward, newForward, ref _smoothForwardVelocity, lookAtHeadSmoothKoef);

    }
}
