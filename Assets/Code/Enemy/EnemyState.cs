using UnityEngine;

public abstract class EnemyState
{
    protected Transform _transform;
    protected IStateProvider _provider;
    protected Animator _anim;

    protected void InitComponents(Transform enemy, IStateProvider swithcer)
    {
        _provider = swithcer;
        _transform = enemy;
        _anim = _transform.GetComponent<Animator>();
    }

    public abstract void Enter();

    public abstract void Update();

    public abstract void HandleHit(int health);

    public abstract void Exit();
}
