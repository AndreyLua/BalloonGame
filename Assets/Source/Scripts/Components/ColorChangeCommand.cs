using UnityEngine;

internal struct ColorChangeCommand
{
    public Color FinalColor;
    public SpriteRenderer SpriteRenderer;
    public float Duration;

    public ColorChangeCommand(Color finalColor, SpriteRenderer spriteRenderer, float duration)
    {
        FinalColor = finalColor;
        SpriteRenderer = spriteRenderer;
        Duration = duration;
    }
}