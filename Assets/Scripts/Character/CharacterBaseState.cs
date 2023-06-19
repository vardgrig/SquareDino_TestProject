using UnityEngine;

public abstract class CharacterBaseState : State
{
    protected readonly CharacterStateMachine stateMachine;
    protected bool isWaypointCompleted = false;

    protected CharacterBaseState(CharacterStateMachine stateMachine)
    {
        this.stateMachine = stateMachine;
    }

    protected void GoToNextWaypoint()
    {
        stateMachine.NavMeshAgent.SetDestination(stateMachine.WaypointTransforms[0].position);
        if (stateMachine.NavMeshAgent.isStopped)
        {
            stateMachine.NavMeshAgent.isStopped = false;
        }
    }
    protected bool IsReachedWaypoint()
    {
        if (stateMachine.transform.position.z >= stateMachine.WaypointTransforms[0].position.z)
        {
            stateMachine.NavMeshAgent.isStopped = true;
            stateMachine.OnWaypointReached();
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
        return false;
        //return isWaypointCompleted;
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