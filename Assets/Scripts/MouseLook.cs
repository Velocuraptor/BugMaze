﻿using UnityEngine;

public class MouseLook : MonoBehaviour
{
    [SerializeField] private Transform _playerBody;
    [SerializeField] private float _mouseSensitivity = 100.0f;    
    private float _xRotation = 0.0f;
    
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
    
    private void Update()
    {
        var mouseX = Input.GetAxis("Mouse X") * _mouseSensitivity * Time.deltaTime;
        var mouseY = Input.GetAxis("Mouse Y") * _mouseSensitivity * Time.deltaTime;

        _xRotation -= mouseY;
        _xRotation = Mathf.Clamp(_xRotation, -90.0f, 90.0f);

        transform.localRotation = Quaternion.Euler(_xRotation, 0.0f, 0.0f);
        _playerBody.Rotate(Vector3.up * mouseX);
    }

}