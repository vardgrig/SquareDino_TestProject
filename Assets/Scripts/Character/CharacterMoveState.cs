using UnityEngine;
public class CharacterMoveState : CharacterBaseState
{
    private readonly string RUN_KEY = "Run";

    public CharacterMoveState(CharacterStateMachine stateMachine) : base(stateMachine) { }

    public override void Enter()
    {
        stateMachine.CharacterAnimator.SetBool(RUN_KEY, true);
        FaceToWaypoint();
        GoToNextWaypoint();
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
        Vector3 direction = stateMachine.WaypointTransforms[0].position - stateMachine.transform.position;
        direction.y = 0f; // Make sure the character only rotates around the Y-axis

        if (direction != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            stateMachine.transform.rotation = targetRotation;
        }
    }
    private bool IsReachedWaypoint()
    {
        if (stateMachine.transform.position.z >= stateMachine.WaypointTransforms[0].position.z)
        {
            stateMachine.OnWaypointReached();
            return true;
        }
        return false;
    }
}