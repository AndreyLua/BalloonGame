using System;
using UnityEngine;

[CreateAssetMenu(fileName = "New LevelConfig", menuName = "LevelConfig")]
public class LevelConfig : ScriptableObject
{
    public Background Background;
    public Ground GroundPrefab;
    public Vector2 StartBackgroundPosition;
    public Vector2 StartGroundPosition;
    public float Speed;
    public float TimeToSpawnEnemy;

    public SerializableDictionary<LineType, float> LineXPositionInTypePair;

    private void OnValidate()
    {
        if (!CheckConfigIsRight() || LineXPositionInTypePair == null)
        {
            LineXPositionInTypePair = new SerializableDictionary<LineType, float>();

            foreach (LineType type in (LineType[])Enum.GetValues(typeof(LineType)))
            {
                LineXPositionInTypePair.Add(type,0);
            }
        }
    }
    private bool CheckConfigIsRight()
    {
        if (LineXPositionInTypePair.Count != Enum.GetValues(typeof(LineType)).Length)
            return false;

        return true;
    }
}
