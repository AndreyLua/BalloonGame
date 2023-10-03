using UnityEngine;

public class Background : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;

    public SpriteRenderer SpriteRenderer => _spriteRenderer;

    private void Awake()
    {
        _spriteRenderer = gameObject.GetComponentInChildren<SpriteRenderer>();
    }
}
