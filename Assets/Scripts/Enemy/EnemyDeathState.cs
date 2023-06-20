
public class EnemyDeathState : EnemyBaseState
{
    private const string ENEMY_DEAD_AUDIO_KEY = "e_dead";

    public EnemyDeathState(EnemyStateMachine stateMachine) : base(stateMachine) { }

    public override void Enter()
    {
        ChangeRagdollState(true);
        AudioManager.instance.Play(ENEMY_DEAD_AUDIO_KEY);
        stateMachine.DestroyEnemy();
    }

    public override void Exit()
    {
    }

    public override void Tick()
    {
    }
}
