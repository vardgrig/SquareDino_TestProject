using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(NavMeshAgent))]
public class CharacterStateMachine : StateMachine
{
    [SerializeField] private float _movementSpeed = 5f;
    [SerializeField] private Transform _mainCameraTransform;
    [SerializeField] private Animator _characterAnimator;
    [SerializeField] private List<Transform> _waypointTransforms;
    [SerializeField] private NavMeshAgent _navMeshAgent;

    public float MovementSpeed => _movementSpeed;
    public Transform MainCameraTransform => _mainCameraTransform;
    public Animator CharacterAnimator => _characterAnimator;
    public List<Transform> WaypointTransforms => _waypointTransforms;
    public NavMeshAgent NavMeshAgent => _navMeshAgent;

    private void Start()
    {
        SwitchState(new CharacterMoveState(this));
    }

    public void OnWaypointReached()
    {
        if (_waypointTransforms.Count > 0)
            _waypointTransforms.RemoveAt(0);
        else
            Debug.Log("Waypoint list is empty!");
    }
}