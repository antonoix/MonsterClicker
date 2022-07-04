using UnityEngine;

public class ClearBoost : Boost
{
    public override void MakeBoost(IBoostHandler handler)
    {
        CreateEffect(Resources.Load("Particles/ClearBoost") as GameObject);
        handler.MakeClearBoost();
        Destroy(gameObject);
    }
}
