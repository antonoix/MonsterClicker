using UnityEngine;

public abstract class BoostFactory
{
    protected Boost _prefab;

    protected BoostFactory(Boost prefab)
    {
        _prefab = prefab;
    }


    public virtual Boost CreateBoost()
    {
        return GameObject.Instantiate(_prefab, MapConfig.GetRandomPointInside(), Quaternion.identity);
    }
}
