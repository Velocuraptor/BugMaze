using System.Collections;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    [SerializeField] private Transform _playerBody;
    [SerializeField] private float _mouseSensitivity = 100.0f;    
    private float _xRotation = 0.0f;

    [SerializeField] private float _maxDistance = 1.0f;
    private IPlayableObject _playableObject;
    
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        StartCoroutine(RaycastGenerator());
    }
    
    private void Update()
    {
        Look();        
        if (Input.GetButtonDown("Execute") && _playableObject != null)
            ExecuteObject();
    }

    private void Look()
    {
        var mouseX = Input.GetAxis("Mouse X") * _mouseSensitivity * Time.deltaTime;
        var mouseY = Input.GetAxis("Mouse Y") * _mouseSensitivity * Time.deltaTime;

        _xRotation -= mouseY;
        _xRotation = Mathf.Clamp(_xRotation, -90.0f, 90.0f);

        transform.localRotation = Quaternion.Euler(_xRotation, 0.0f, 0.0f);
        _playerBody.Rotate(Vector3.up * mouseX);
    }

    private void ExecuteObject() => _playableObject.Execute();

    private IEnumerator RaycastGenerator()
    {
        while (true)
        {
            GenerateRaycast();
            yield return new WaitForSeconds(0.6f);
        }
    }

    private void GenerateRaycast()
    {
        var ray = new Ray(transform.position, transform.forward);
        var isHit = Physics.Raycast(ray, out var hitInfo, _maxDistance);
        if (!isHit)
        {
            _playableObject?.CloseOutline();
            _playableObject = null;
            return;
        }
        var newPlayableObject = hitInfo.collider.gameObject.GetComponent<IPlayableObject>();
        if (newPlayableObject == null)
            return;

        if (_playableObject != newPlayableObject)
        {
            _playableObject?.CloseOutline();
            _playableObject = newPlayableObject;
            _playableObject.ShowOutline();
        }
    }
}
