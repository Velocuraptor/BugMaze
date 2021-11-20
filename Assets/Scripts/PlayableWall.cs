using UnityEngine;

public class PlayableWall : MonoBehaviour, IPlayableObject
{
    [SerializeField] private MeshRenderer _meshRenderer;
    [SerializeField] private Material _material;

    public void Execute()
    {
        gameObject.SetActive(false);
    }

    public void ShowOutline()
    {
        _meshRenderer.material = null;
    }

    public void CloseOutline()
    {
        _meshRenderer.material = _material;
    }
}
