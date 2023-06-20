using System;

public class GameStateMachine : StateMachine
{
    public Action OnGameStarted;
    private void Start()
    {
        SwitchState(new GameStartState(this));
    }
}
