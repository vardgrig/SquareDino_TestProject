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

            stateMachine.Waypoints[0].PrintEnemies();
            stateMachine.NavMeshAgent.isStopped = true;
            return true;
        }
        return false;
    }
    protected void Shoot()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Shoot");
            var tapPosition = GetTapDirection();
            stateMachine.BulletPool.ShootBullet(tapPosition);
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
    private Vector3 GetTapDirection()
    {
        Ray ray = stateMachine.MainCamera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            var hitPosition = hit.point;
            return hitPosition;
        }
        else
        {
            var mousePos = Input.mousePosition;
            mousePos += stateMachine.MainCameraTransform.forward * 20f;
            var direction = stateMachine.MainCamera.ScreenToWorldPoint(mousePos);
            return direction;
        }
    }
}