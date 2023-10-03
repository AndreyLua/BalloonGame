using UnityEngine;

[CreateAssetMenu(fileName = "New BalloonConfig", menuName = "BalloonConfig")]
public class BalloonConfig : ScriptableObject
{
    public Balloon Prefab;
    public Vector2 StartPosition;
}
