using System;
using UnityEngine;

public class DyingState : EnemyState
{
    public event Action OnDied;

    public DyingState(Transform transform, IStateProvider swithcer)
    {
        InitComponents(transform, swithcer);
    }

    public override void Enter()
    {
        _anim.SetTrigger("Die");
        OnDied?.Invoke();
    }

    public override void Exit()
    {
        //throw new System.NotImplementedException();
    }

    public override void HandleHit(int health)
    {
        //throw new System.NotImplementedException();
    }

    public override void Update()
    {
        //throw new System.NotImplementedException();
    }
}
