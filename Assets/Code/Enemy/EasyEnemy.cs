public class EasyEnemy : Enemy, ITouchable
{
    private void Start()
    {
        SwithState(_movingState);
    }

    private void Update()
    {
        _currentState.Update();
    }

    public void HandleTouch()
    {
        _currentState.HandleHit(--_currentHealth);
    }
}
