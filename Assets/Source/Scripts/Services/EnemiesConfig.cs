using System;
using UnityEngine;

[CreateAssetMenu(fileName = "New EnemiesConfig", menuName = "EnemiesConfig")]
public class EnemiesConfig : ScriptableObject
{
    public SerializableDictionary<EnemyType, EnemyBase> EnemyBaseInTypePairs;

}
