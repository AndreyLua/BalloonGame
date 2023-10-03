using DG.Tweening;
using Leopotam.Ecs;
using System;
using UnityEngine;

public class SpawnEnemiesSystem : IEcsInitSystem
{
    private EcsWorld _ecsWorld;
    private LevelConfig _levelConfig;
    private EnemiesConfig _enemiesConfig;

    private Pool<EnemyBase, EnemyType> _enemiesPool;
    private Sequence _spawnSequence;

    public void Init()
    {
        _enemiesPool = new Pool<EnemyBase, EnemyType>(SpawnEnemy);
        StartSpawnEnemies();
    }

    private void StartSpawnEnemies()
    {
        _spawnSequence = DOTween.Sequence().AppendInterval(_levelConfig.TimeToSpawnEnemy).AppendCallback(() =>
        {
            EnemyBase enemy = _enemiesPool.ExtractElement(EnemyType.Common);

            StartSpawnEnemies();
        });
    }

    public void StopSpawnEnemies()
    {
        _spawnSequence.Kill();
    }

    private LineType GetRandomLineType()
    {
        Array values = Enum.GetValues(typeof(LineType));
        LineType randomLine = (LineType)values.GetValue(UnityEngine.Random.Range(0, values.Length));

        return randomLine;
    }

    private EnemyBase SpawnEnemy(EnemyType type)
    {
        EnemyBase enemyPrefab = _enemiesConfig.EnemyBaseInTypePairs[type];
        EcsEntity enemyEntity = _ecsWorld.NewEntity();

        LineType lineType = GetRandomLineType();
        Vector2 position = new Vector2(_levelConfig.LineXPositionInTypePair[lineType], 6);

        EnemyBase enemyBase = UnityEngine.Object.Instantiate(enemyPrefab,
            position, Quaternion.identity);

        ModelComponent model = new ModelComponent(enemyBase.transform);
        LineComponent line = new LineComponent(lineType);
        MoveableComponent moveable = new MoveableComponent(Vector2.down, _levelConfig.Speed);

        enemyEntity.Replace(model).Replace(line).Replace(moveable);
        return enemyBase;
    }
}
    
