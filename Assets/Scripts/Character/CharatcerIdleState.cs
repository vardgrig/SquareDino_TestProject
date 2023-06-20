using UnityEngine;
public class CharacterIdleState : CharacterBaseState
{
    private readonly string RUN_KEY = "Run";
    public CharacterIdleState(CharacterStateMachine stateMachine) : base(stateMachine) { }

    public override void Enter()
    {
        stateMachine.CharacterAnimator.SetBool(RUN_KEY, false);
        stateMachine.GameStateMachine.OnGameStarted += StartGame;
        if(stateMachine.IsGameStarted)
            stateMachine.SwitchState(new CharatcerShootingState(stateMachine));
    }

    public override void Tick()
    {
    }

    public override void Exit()
    {
        stateMachine.GameStateMachine.OnGameStarted += StartGame;
    }

    private void StartGame()
    {
        stateMachine.IsGameStarted = true;
        stateMachine.SwitchState(new CharacterMoveState(stateMachine));
    }
}