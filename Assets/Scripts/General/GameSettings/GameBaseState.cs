public abstract class GameBaseState : State
{
    protected GameStateMachine stateMachine;
    protected bool isGameStarted = false;
    protected GameBaseState(GameStateMachine stateMachine)
    {
        this.stateMachine = stateMachine;
    }

    protected void SetMaximumFrameRate()
    {
        GameSettingsUtils.SetMaximumFrameRate();
    }
    protected void StartGame()
    {
        isGameStarted = true;
        stateMachine.OnGameStarted?.Invoke();
    }
}
