public abstract class CharacterBaseState : State
{
    protected readonly CharacterStateMachine stateMachine;

    protected CharacterBaseState(CharacterStateMachine stateMachine)
    {
        this.stateMachine = stateMachine;
    }
    
    protected void GoToNextWaypoint()
    {
        stateMachine.NavMeshAgent.SetDestination(stateMachine.WaypointTransforms[0].position);
    }

    protected void Shoot()
    {

    }
}