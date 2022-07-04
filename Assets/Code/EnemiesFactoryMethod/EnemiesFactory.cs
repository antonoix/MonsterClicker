using UnityEngine;

public abstract class EnemiesFactory
{
    protected Enemy _prefab;

    protected EnemiesFactory(Enemy prefab)
    {
        _prefab = prefab;
    }


    public virtual Enemy CreateEnemy()
    {
        return GameObject.Instantiate(_prefab, MapConfig.GetRandomPointOutside(), Quaternion.identity);
    }
}
