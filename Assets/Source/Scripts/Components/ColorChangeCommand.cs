using UnityEngine;

internal struct ColorChangeCommand
{
    public Color FinalColor;
    public float Duration;

    public ColorChangeCommand(Color finalColor, float duration)
    {
        FinalColor = finalColor;
        Duration = duration;
    }
}
