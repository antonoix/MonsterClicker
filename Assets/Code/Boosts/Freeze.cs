using UnityEngine;

public class Freeze : Boost
{
    public override void MakeBoost(IBoostHandler handler)
    {
        CreateEffect(Resources.Load("Particles/FreezeBoost") as GameObject);
        handler.MakeFreezeBoost();
        Destroy(gameObject);
    }
}
