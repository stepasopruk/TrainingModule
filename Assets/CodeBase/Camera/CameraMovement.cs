using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    #region Constant
    private const float MIN_X_ROTATION_ANGLE = -80;
    private const float MAX_X_ROTATION_ANGLE = 80;
    #endregion

    #region Serialized
    [SerializeField] 
    private Transform target;
    [SerializeField] 
    private Camera mainCamera;
    [SerializeField] 
    private float distanceBetweenCameraAndTarget;

    [SerializeField, Range(0.1f, 5f)]
    private float mouseRotateSpeed = 0.8f;

    [SerializeField, Range(0.01f, 100)]
    private float slerpRotationValue = 0.25f;

    [SerializeField, Range(0.01f, 0.1f)]
    private float slerpZoomValue = 0.01f;

    [SerializeField, Min(0.01f)]
    private float minZoom = 0.05f;
    [SerializeField]
    private float maxZoom = 0.5f;
    #endregion

    private Quaternion _cameraRotation;
    private Vector3 _diraction;

    private float _rotationX;
    private float _rotationY;
    private float _zoom;

    private void Awake()
    {
        if (mainCamera == null)
            mainCamera = Camera.main;

        _diraction = new Vector3(0, 0, -distanceBetweenCameraAndTarget);
        _zoom = mainCamera.orthographicSize;
    }

    private void Update()
    {
        CameraRotation();
        CameraZoom();
    }

    private void LateUpdate()
    {
        Quaternion newAngle = Quaternion.Euler(_rotationX, _rotationY, 0);

        _cameraRotation = Quaternion.Slerp(_cameraRotation, newAngle, slerpRotationValue);
        mainCamera.orthographicSize = Mathf.Lerp(mainCamera.orthographicSize, _zoom, slerpZoomValue);
        mainCamera.transform.position = target.position + _cameraRotation * _diraction;

        mainCamera.transform.LookAt(target.position, Vector3.up);
    }

    private void CameraRotation()
    {
        if (Input.GetMouseButton(0))
        {
            _rotationX += -Input.GetAxis("Mouse Y") * mouseRotateSpeed;
            _rotationY += Input.GetAxis("Mouse X") * mouseRotateSpeed;
        }

        if (_rotationX < MIN_X_ROTATION_ANGLE)
            _rotationX = MIN_X_ROTATION_ANGLE;
        else if (_rotationX > MAX_X_ROTATION_ANGLE)
            _rotationX = MAX_X_ROTATION_ANGLE;
    }

    private void CameraZoom()
    {
        _zoom += -Input.GetAxis("Mouse ScrollWheel");

        if (_zoom < minZoom)
            _zoom = minZoom;
        else if (_zoom > maxZoom)
            _zoom = maxZoom;
    }
}
