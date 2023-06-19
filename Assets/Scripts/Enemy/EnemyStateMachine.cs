using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class EnemyStateMachine : StateMachine, IEnemy
{
    [SerializeField] private Animator _enemyAnimator;
    [SerializeField] private Collider _enemyCollider;
    [SerializeField] private Rigidbody _enemyRigidbody;
    [SerializeField] private int _enemyHealth;
    [SerializeField] private List<Rigidbody> _enemyRagdollRigidbodies;
    [SerializeField] private List<Collider> _enemyRagdollColliders;
    [SerializeField] private float _enemyLifetimeAfterDeath;

    public Animator EnemyAnimator => _enemyAnimator;
    public int EnemyHealth => _enemyHealth;
    public Rigidbody EnemyRigidbody => _enemyRigidbody;
    public Collider EnemyCollider => _enemyCollider;
    public List<Rigidbody> EnemyRagdollRigidbodies => _enemyRagdollRigidbodies;
    public List<Collider> EnemyRagdollColliders => _enemyRagdollColliders;
    public float EnemyLifetimeAfterDeath => _enemyLifetimeAfterDeath;

    private void Start()
    {
        SwitchState(new EnemyIdleState(this));
    }
    public void TakeDamage(int damage)
    {
        if(damage >= _enemyHealth)
        {
            _enemyHealth = 0;
            return;
        }
        _enemyHealth -= damage;
    }

    public void DestroyEnemy()
    {
        StartCoroutine(Lifetime());
    }

    private IEnumerator Lifetime()
    {
        yield return new WaitForSeconds(_enemyLifetimeAfterDeath);
        Destroy(this.gameObject);
    }
}