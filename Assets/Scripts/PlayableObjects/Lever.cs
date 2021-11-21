using UnityEngine;

public class Lever : MonoBehaviour, IPlayableObject
{
    [SerializeField] private Outline _outLine;
    [SerializeField] private Animator _animator;

    [SerializeField] private GameObject[] _activateWalls;
    [SerializeField] private GameObject[] _deactivateWalls;

    private bool _isPressed = false;

    public void CloseOutline()
    {
        _outLine.enabled = false;
    }

    public void Execute()
    {
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
}
