using System;
using UnityEngine;

public class StrategyCameraMove : SingletonBase<StrategyCameraMove>
{
    [Header("Camera Movement Settings")]
    [Space]
    [SerializeField] private Vector2 startPosition;
    [SerializeField] private Camera mainCamera;
    
    [Header("Speed Settings")]
    [Space]
    [SerializeField] private float speedHorizontal = 2f;
    [SerializeField] private float speedRotate = 2f;
    [SerializeField] private float speedZoom = 2f;
    
    [Header("Bounds Settings")]
    [Space]
    //[SerializeField] private float minHeight = 3f;
    [SerializeField] private float maxHeight = 10f;

    private float _rotationY;
    private void Awake()
    {
        Init();
    }

    private void Start()
    {
        SpawnCamera();
    }

    private void SpawnCamera()
    {
        transform.position = new Vector3( startPosition.x,0,  startPosition.y);
        mainCamera.transform.position = new Vector3(mainCamera.transform.position.x, maxHeight, mainCamera.transform.position.z);
        mainCamera.transform.LookAt(transform);
    }

    public void Move(float directionX, float directionZ,bool isAcceleration)
    {
        var forward = transform.forward * directionZ;
        var right = transform.right * directionX;
        var dir = Vector3.ClampMagnitude(forward + right,1f);
        
        var acceleration = speedHorizontal;
        if (isAcceleration) acceleration = speedHorizontal * 2;
        
        transform.position += dir * (acceleration * Time.deltaTime);
    }
    
    public void Zoom(float directionY)
    {
        var offset = mainCamera.transform.forward * -directionY;
        mainCamera.transform.position += offset * (speedZoom * Time.deltaTime);
    }
    
    public void Rotate(float directionY)
    {
        _rotationY += -directionY * speedRotate;
        var xQuat = Quaternion.AngleAxis(_rotationY, Vector3.up);
        transform.rotation = xQuat;
    }
}
