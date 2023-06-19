public class CharacterIdleState : CharacterBaseState
{
    private readonly string RUN_KEY = "Run";
    public CharacterIdleState(CharacterStateMachine stateMachine) : base(stateMachine) { }

    public override void Enter()
    {
        stateMachine.CharacterAnimator.SetBool(RUN_KEY, false);
    }

    public override void Tick()
    {
    }

    public override void Exit()
    {
    }
}