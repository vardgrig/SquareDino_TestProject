using UnityEngine;
using UnityEngine.SceneManagement;

public abstract class CharacterBaseState : State
{
    protected readonly CharacterStateMachine stateMachine;
    protected CharacterBaseState(CharacterStateMachine stateMachine)
    {
        this.stateMachine = stateMachine;
    }

    protected void GoToNextWaypoint()
    {
        stateMachine.NavMeshAgent.SetDestination(stateMachine.Waypoints[0].transform.position);
        if (stateMachine.NavMeshAgent.isStopped)
        {
            stateMachine.NavMeshAgent.isStopped = false;
        }
    }
    protected bool IsReachedWaypoint()
    {
        if (stateMachine.transform.position.z >= stateMachine.Waypoints[0].transform.position.z)
        {
            if (stateMachine.Waypoints[0].IsFinalWaypoint)
            {
                Debug.Log("Finish");
                SceneManager.LoadScene(0);
            }

            stateMachine.NavMeshAgent.isStopped = true;
            return true;
        }
        return false;
    }
    protected void Shoot(string audioKey)
    {
        if (Input.GetMouseButtonDown(0))
        {
            var tapPosition = TapUtils.GetTapDirection();
            stateMachine.BulletPool.ShootBullet(tapPosition);
            AudioManager.instance.Play(audioKey);
        }
    }
    protected bool IsWaypointCompleted()
    {
        if (stateMachine.Waypoints[0].GetEnemiesCountInThisWaypoint == 0)
        {
            stateMachine.OnWaypointReached();
            return true;
        }
        return false;
    }
}