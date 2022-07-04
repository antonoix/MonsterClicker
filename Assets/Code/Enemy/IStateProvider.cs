public interface IStateProvider
{
    public void SwithState(EnemyState state);

    public EnemyState MovingState { get; }
    public EnemyState DyingState { get; }
    public EnemyConfig Config { get; }
}
