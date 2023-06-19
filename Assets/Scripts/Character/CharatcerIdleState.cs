using UnityEngine;
public class CharacterIdleState : CharacterBaseState
{
    private readonly string RUN_KEY = "Run";
    public CharacterIdleState(CharacterStateMachine stateMachine) : base(stateMachine) { }

    public override void Enter()
    {
        Debug.Log("Entering Idle State");
        stateMachine.CharacterAnimator.SetBool(RUN_KEY, false);
    }

    public override void Tick()
    {
        Shoot();
        if(isWaypointCompleted)
        {
            stateMachine.SwitchState(new CharacterMoveState(stateMachine));
        }
    }

    public override void Exit()
    {
    }
}