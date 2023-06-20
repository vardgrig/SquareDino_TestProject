using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Animator))]
public class EnemyStateMachine : StateMachine, IEnemy
{
    private const string ENEMY_HIT_AUDIO_KEY = "e_hit";

    [SerializeField] private Animator _enemyAnimator;
    [SerializeField] private Collider _enemyCollider;
    [SerializeField] private Rigidbody _enemyRigidbody;
    [SerializeField] private int _enemyHealth;
    [SerializeField] private List<Rigidbody> _enemyRagdollRigidbodies;
    [SerializeField] private List<Collider> _enemyRagdollColliders;
    [SerializeField] private float _enemyLifetimeAfterDeath;
    [SerializeField] private Waypoint _waypoint;
    [SerializeField] private Slider _healthBarSlider;
    [SerializeField] private TextMeshProUGUI _healthBarTextUGUI;

    public Animator EnemyAnimator => _enemyAnimator;
    public int EnemyHealth => _enemyHealth;
    public Rigidbody EnemyRigidbody => _enemyRigidbody;
    public Collider EnemyCollider => _enemyCollider;
    public List<Rigidbody> EnemyRagdollRigidbodies => _enemyRagdollRigidbodies;
    public List<Collider> EnemyRagdollColliders => _enemyRagdollColliders;
    public Waypoint Waypoint => _waypoint;

    private void Start()
    {
        SetupUI();
        SwitchState(new EnemyIdleState(this));
    }

    private void SetupUI()
    {
        _healthBarSlider.maxValue = _enemyHealth;
        _healthBarSlider.minValue = 0;
        _healthBarTextUGUI.text = _enemyHealth.ToString();
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
        _healthBarTextUGUI.text = _enemyHealth.ToString();
    }

    public void TakeDamage(int damage)
    {
        ChangeSliderValue(damage);
        if(damage >= _enemyHealth)
        {
            _enemyHealth = 0;
            return;
        }
        AudioManager.instance.Play(ENEMY_HIT_AUDIO_KEY);
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