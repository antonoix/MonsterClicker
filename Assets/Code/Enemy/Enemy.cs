using System;
using System.Collections;
using UnityEngine;

public abstract class Enemy : MonoBehaviour, IStateProvider
{
    public event  Action<Enemy> OnDied;

    [SerializeField] protected EnemyConfig _config;
    protected int _currentHealth;

    protected EnemyState _currentState;

    protected MovingState _movingState;
    protected DyingState _dyingState;

    public EnemyState MovingState => _movingState;

    public EnemyState DyingState => _dyingState;
    public EnemyConfig Config => _config;

    public void SwithState(EnemyState state)
    {
        if (_currentState != null)
            _currentState.Exit();
        _currentState = state;
        _currentState.Enter();
    }

    protected virtual void Awake()
    {
        _currentHealth = _config.Health;
        _movingState = new MovingState(transform, this);
        _dyingState = new DyingState(transform, this);
        _dyingState.OnDied += HandleDeath;
    }

    protected void HandleDeath()
    {
        OnDied?.Invoke(this);
        StartCoroutine(Die());
    }

    public void Kill()
    {
        SwithState(_dyingState);
    }

    private IEnumerator Die()
    {
        var startParticlesObject = Resources.Load("Particles/StartDie") as GameObject;
        startParticlesObject = Instantiate(startParticlesObject, transform);
        startParticlesObject.GetComponent<ParticleSystem>().Play();
        yield return new WaitForSeconds(2);
        var finishParticlesObject = Resources.Load("Particles/FinishDie") as GameObject;
        finishParticlesObject = Instantiate(finishParticlesObject, transform.position, Quaternion.identity);
        finishParticlesObject.GetComponent<ParticleSystem>().Play();
        GameObject.Destroy(gameObject);
    }
}
