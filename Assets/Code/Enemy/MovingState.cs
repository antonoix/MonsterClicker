using UnityEngine;

public class MovingState : EnemyState
{
    private Vector3 _destination;
    private ParticleSystem _particles;

    public MovingState(Transform transform, IStateProvider provider)
    {
        InitComponents(transform, provider);
        var hitParticles = Resources.Load("Particles/Hit") as GameObject;
        hitParticles = GameObject.Instantiate(hitParticles, _transform);
        _particles = hitParticles.GetComponent<ParticleSystem>();
    }

    public override void Enter()
    {
        SetDestination();
        _anim.SetBool("Run", true);
    }

    public override void Exit()
    {
        _anim.SetBool("Run", false);
    }

    public override void HandleHit(int health)
    {
        _particles.Play();
        if (health <= 0)
        {
            _provider.SwithState(_provider.DyingState);
        }
    }

    public override void Update()
    {
        var step = Vector3.forward * Time.deltaTime * _provider.Config.Speed;
        _transform.Translate(step);
        if ((_transform.position - _destination).magnitude < step.magnitude * 2)
            SetDestination();
    }

    private void SetDestination()
    {
        _destination = MapConfig.GetRandomPointInside();
        _transform.LookAt(_destination);
    }
}
