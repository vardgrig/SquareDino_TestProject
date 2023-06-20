using UnityEngine;

public class GameStartState : GameBaseState
{
    private const string BACKGROUND_MUSIC_KEY = "background";
    public GameStartState(GameStateMachine stateMachine) : base(stateMachine) { }

    public override void Enter()
    {
        SetMaximumFrameRate();
        AudioManager.instance.Play(BACKGROUND_MUSIC_KEY);
    }
    public override void Tick()
    {
        if (isGameStarted)
            return;

        if (Input.GetMouseButtonDown(0))
        {
            StartGame();
        }
    }

    public override void Exit()
    {
    }  
}