using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

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
    [SerializeField] private Waypoint _waypoint;
    [SerializeField] private Slider _healthBarSlider;

    public Animator EnemyAnimator => _enemyAnimator;
    public int EnemyHealth => _enemyHealth;
    public Rigidbody EnemyRigidbody => _enemyRigidbody;
    public Collider EnemyCollider => _enemyCollider;
    public List<Rigidbody> EnemyRagdollRigidbodies => _enemyRagdollRigidbodies;
    public List<Collider> EnemyRagdollColliders => _enemyRagdollColliders;
    public float EnemyLifetimeAfterDeath => _enemyLifetimeAfterDeath;
    public Waypoint Waypoint => _waypoint;
    public Slider HealthBarSlider => _healthBarSlider;

    private void Start()
    {
        SetupUI();
        SwitchState(new EnemyIdleState(this));
    }

    private void SetupUI()
    {
        _healthBarSlider.maxValue = _enemyHealth;
        _healthBarSlider.minValue = 0;
        _healthBarSlider.value = _healthBarSlider.maxValue;
    }

    private void ChangeSliderValue(int valueToChange)
    {
        if(valueToChange >= _healthBarSlider.value)
        {
            _healthBarSlider.gameObject.SetActive(false);
            return;
        }
        _healthBarSlider.value -= valueToChange;
    }

    public void TakeDamage(int damage)
    {
        ChangeSliderValue(damage);
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