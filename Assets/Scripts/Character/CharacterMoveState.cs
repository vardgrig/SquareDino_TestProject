using UnityEngine;
public class CharacterMoveState : CharacterBaseState
{
    private readonly string RUN_KEY = "Run";

    public CharacterMoveState(CharacterStateMachine stateMachine) : base(stateMachine) { }

    public override void Enter()
    {
        stateMachine.CharacterAnimator.SetBool(RUN_KEY, true);
        GoToNextWaypoint();
        FaceToWaypoint();
    }

    public override void Tick()
    {
        if(IsReachedWaypoint())
        {
            stateMachine.SwitchState(new CharacterIdleState(stateMachine));
        }
    }
    public override void Exit()
    {
    }
    private void FaceToWaypoint()
    {
        Vector3 waypointPosition = stateMachine.Waypoints[0].transform.position;
        stateMachine.transform.LookAt(waypointPosition);
    }
}