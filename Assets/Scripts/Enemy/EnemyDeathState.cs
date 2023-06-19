using System.Collections;
using UnityEngine;

public class EnemyDeathState : EnemyBaseState
{
    public EnemyDeathState(EnemyStateMachine stateMachine) : base(stateMachine) { }

    public override void Enter()
    {
        ChangeRagdollState(true);
        stateMachine.DestroyEnemy();
    }

    public override void Exit()
    {
    }

    public override void Tick()
    {
    }
}
