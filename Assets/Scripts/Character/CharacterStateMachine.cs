using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(NavMeshAgent))]
public class CharacterStateMachine : StateMachine
{
    [SerializeField] private float _movementSpeed = 5f;
    [SerializeField] private Camera _mainCamera;
    [SerializeField] private Animator _characterAnimator;
    [SerializeField] private List<Waypoint> _waypoints;
    [SerializeField] private NavMeshAgent _navMeshAgent;
    [SerializeField] private BulletPool _bulletPool;
    [SerializeField] private GameStateMachine _gameStateMachine;

    public float MovementSpeed => _movementSpeed;
    public Camera MainCamera => _mainCamera;
    public Transform MainCameraTransform => _mainCamera.transform;
    public Animator CharacterAnimator => _characterAnimator;
    public List<Waypoint> Waypoints => _waypoints;
    public NavMeshAgent NavMeshAgent => _navMeshAgent;
    public BulletPool BulletPool => _bulletPool;
    public GameStateMachine GameStateMachine => _gameStateMachine;
    public bool IsGameStarted { get; set; }

    private void Start()
    {
        SwitchState(new CharacterIdleState(this));
    }

    public void OnWaypointReached()
    {
        if (_waypoints.Count > 0)
            _waypoints.RemoveAt(0);
        else
            Debug.Log("Waypoint list is empty!");
    }
}