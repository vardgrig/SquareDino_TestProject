public class EnemyIdleState : EnemyBaseState
{
    public EnemyIdleState(EnemyStateMachine stateMachine) : base(stateMachine) { }

    public override void Enter()
    {
        ChangeRagdollState(false);
    }

    public override void Tick()
    {
        if(IsDead())
        {
            stateMachine.SwitchState(new EnemyDeathState(stateMachine));
        }
    }

    public override void Exit()
    {
    }
}
