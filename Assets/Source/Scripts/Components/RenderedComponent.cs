using UnityEngine;

internal struct RenderedComponent
{
    public SpriteRenderer SpriteRenderer;
   
    public RenderedComponent(SpriteRenderer spriteRenderer)
    {
        SpriteRenderer = spriteRenderer;
    }
}