using UnityEngine;

public class Lever : MonoBehaviour, IPlayableObject, IBug
{
    [SerializeField] private Outline _outLine;
    [SerializeField] private Animator _animator;
    [SerializeField] private bool _isBug;
    [SerializeField] private string _bugReport;
    [SerializeField] private GameObject[] _activateWalls;
    [SerializeField] private GameObject[] _deactivateWalls;
    public string BugReport => _bugReport;
    public bool IsBug => _isBug;

    private bool _isPressed = false;


    public void CloseOutline()
    {
        _outLine.enabled = false;
    }

    public void Execute()
    {
        if(IsBug)
        {
            ActivateBug();
            return;
        }

        _isPressed = true;
        _outLine.enabled = false;
        _animator.SetTrigger("Execute");
        ActivateWalls();
        DeactivateWalls();
    }

    public void ShowOutline()
    {
        if (_isPressed)
            return;
        _outLine.enabled = true;
    }

    private void ActivateWalls()
    {
        foreach (var wall in _activateWalls)
            wall.SetActive(true);
    }

    private void DeactivateWalls()
    {
        foreach (var wall in _deactivateWalls)
            wall.SetActive(false);
    }

    public void ActivateBug()
    {
        gameObject.AddComponent<Rigidbody>();
        _isPressed = true;
    }
}
