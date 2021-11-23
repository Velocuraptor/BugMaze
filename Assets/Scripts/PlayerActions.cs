using System;
using UnityEngine;

public class PlayerActions : MonoBehaviour
{
    [SerializeField] private float _maxDistance = 1.0f;
    private IPlayableObject _playableObject;
    private Notebook _notebook;

    private void Start()
    {
        _notebook = Notebook.GetInstance();
    }

    private void Update()
    {
        GenerateRaycast();

        if (Input.GetButtonDown("Notice"))
            TriggerBug();

        if (Input.GetButtonDown("Execute") && _playableObject != null)
            ExecuteObject();
    }

    private void TriggerBug()
    {
        var ray = new Ray(transform.position, transform.forward);
        var isHit = Physics.Raycast(ray, out var hitInfo, _maxDistance);
        if (!isHit)
            return;
        var bug = hitInfo.collider.gameObject.GetComponent<IBug>();
        if (bug == null)
            return;
        if(bug.IsBug)
            _notebook.NoticeBug(bug.BugReport);
    }

    private void ExecuteObject() => _playableObject.Execute();

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
