public class CharatcerShootingState : CharacterBaseState
{
    private const string WEAPON_SHOT_KEY = "w_shot";
    public CharatcerShootingState(CharacterStateMachine stateMachine) : base(stateMachine) { }

    public override void Enter()
    {
    }

    public override void Tick()
    {
        Shoot(WEAPON_SHOT_KEY);
        if (IsWaypointCompleted())
        {
            stateMachine.SwitchState(new CharacterMoveState(stateMachine));
        }
    }

    public override void Exit()
    {
        
    }
}
