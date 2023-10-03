using DG.Tweening;
using Leopotam.Ecs;
using System;
using UnityEngine;

public class SpawnEnemiesSystem : IEcsInitSystem, IEcsRunSystem
{
    private EcsWorld _ecsWorld;
    private LevelConfig _levelConfig;
    private EnemiesConfig _enemiesConfig;
    private EcsFilter<Paused, PlayerTag> _pauseFilter;
    private EcsFilter<RestartEvent, PlayerTag> _restartFilter;

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
            enemy.gameObject.SetActive(true);

            EcsEntity enemyEntity = _ecsWorld.NewEntity();

            ModelComponent model = new ModelComponent(enemy.transform);
            LineComponent line = new LineComponent(LineType.Left);
            MoveableComponent moveable = new MoveableComponent(Vector2.down, _levelConfig.Speed);
            EnemyTag tag = new EnemyTag(enemy);
            
            LineType lineType = GetRandomLineType();
            line.LineType = lineType;
            model.Transform.position = GetStartPosition(lineType);

            enemyEntity.Replace(model)
            .Replace(line)
            .Replace(moveable)
            .Replace(tag);

            StartSpawnEnemies();
        });
    }

    private void StopSpawnEnemies()
    {
        _spawnSequence.Kill();
    }

    private LineType GetRandomLineType()
    {
        Array values = Enum.GetValues(typeof(LineType));
        LineType randomLine = (LineType)values.GetValue(UnityEngine.Random.Range(0, values.Length));

        return randomLine;
    }

    private Vector2 GetStartPosition(LineType lineType)
    {
        return new Vector2(_levelConfig.LineXPositionInTypePair[lineType], 6);
    }

    private EnemyBase SpawnEnemy(EnemyType type)
    {
        EnemyBase enemyPrefab = _enemiesConfig.EnemyBaseInTypePairs[type];
       
        EnemyBase enemyBase = UnityEngine.Object.Instantiate(enemyPrefab,
            Vector2.zero, Quaternion.identity);
        return enemyBase;
    }

    public void Run()
    {
        if (_spawnSequence.active)
        {
            foreach (int i in _pauseFilter)
            {
                StopSpawnEnemies();
                break;
            }
        }
        else
        {
            foreach (int i in _restartFilter)
            {
                StartSpawnEnemies();
                break;
            }
        }
    }
}