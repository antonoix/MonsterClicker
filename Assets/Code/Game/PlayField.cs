using System.Collections;
using UnityEngine;

public class PlayField : MonoBehaviour
{
    [SerializeField] private EasyEnemy _easyEnemyPrefab;
    [SerializeField] private MiddleEnemy _middleEnemyPrefab;
    private EasyEnemiesFactory _easyEnemiesFactory;
    private MiddleEnemiesFactory _middleEnemiesFactory;

    [SerializeField] private Freeze _freezeBoostPrefab;
    [SerializeField] private ClearBoost _clearBoostPrefab;
    private FreezeFactory _freezeFactory;
    private ClearBoostFactory _clearFactory;

    [SerializeField] private LightController _lights;
    private float _enemySpawnInterval = 5;
    private float _boostSpawnInterval = 15;
    private Coroutine _makeEnemies;

    void Start()
    {
        _easyEnemiesFactory = new EasyEnemiesFactory(_easyEnemyPrefab);
        _middleEnemiesFactory = new MiddleEnemiesFactory(_middleEnemyPrefab);
        _freezeFactory = new FreezeFactory(_freezeBoostPrefab);
        _clearFactory = new ClearBoostFactory(_clearBoostPrefab);
        _makeEnemies = StartCoroutine(CreateEnemies());
        StartCoroutine(CreateBoosts());
    }

    public void StopCreatingEnemies()
    {
        StopCoroutine(_makeEnemies);
    }

    public void StartCreatingEnemies()
    {
        _makeEnemies = StartCoroutine(CreateEnemies());
    }

    public IEnumerator Freeze(float duration = 3)
    {
        StopCreatingEnemies();
        yield return new WaitForSeconds(duration);
        StartCreatingEnemies();
    }

    #region enemyCreating
    private IEnumerator CreateEnemies()
    {
        while(true)
        {
            CreateRandomEnemy();
            DecreaseInterval();
            yield return new WaitForSeconds(_enemySpawnInterval);
        }
    }

    private void CreateRandomEnemy()
    {
        var chance = (int)Time.realtimeSinceStartup / 10;
        Enemy enemy;
        if (Random.Range(1, 11) < chance)
            enemy = _middleEnemiesFactory.CreateEnemy();
        else
            enemy = _easyEnemiesFactory.CreateEnemy();
        _lights.ActivateLight(enemy.transform.position);
    }

    private void DecreaseInterval()
    {
        _enemySpawnInterval -= 0.5f;
        _enemySpawnInterval = Mathf.Clamp(_enemySpawnInterval, 1, float.MaxValue);
    }
    #endregion

    private IEnumerator CreateBoosts()
    {
        while(true)
        {
            yield return new WaitForSeconds(_boostSpawnInterval);
            CreateRandomBoost();
        }
    }

    private void CreateRandomBoost()
    {
        if (Random.Range(0, 2) == 0)
            _freezeFactory.CreateBoost();
        else
            _clearFactory.CreateBoost();
    }
}
