using UnityEngine;

public abstract class EnemyBaseState : State
{
    protected readonly EnemyStateMachine stateMachine;

    protected EnemyBaseState(EnemyStateMachine stateMachine)
    {
        this.stateMachine = stateMachine;
    }
    protected bool IsDead()
    {
        return stateMachine.EnemyHealth <= 0;
    }

    protected void ChangeRagdollState(bool activate)
    {
        stateMachine.EnemyAnimator.enabled = !activate;
        stateMachine.EnemyRigidbody.isKinematic = activate;
        stateMachine.EnemyCollider.enabled = !activate;

        foreach(var rigidbody in stateMachine.EnemyRagdollRigidbodies)
        {
            rigidbody.isKinematic = !activate;
        }

        foreach(var collider in stateMachine.EnemyRagdollColliders)
        {
            collider.enabled = activate;
        }
    }
}
