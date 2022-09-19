using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtMainCamera : MonoBehaviour
{
    [Tooltip("Usually for UI you want to be it checked.")]
    public bool mirrorLook = true;
    private Transform _camera;
    void Start()
    {
        _camera = Camera.main.transform;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 directionToCamera = (_camera.position - transform.position).normalized;
        directionToCamera = mirrorLook ? directionToCamera * -1f : directionToCamera;
        transform.forward = directionToCamera;
    }
}
