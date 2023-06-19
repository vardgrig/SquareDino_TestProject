using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private Rigidbody _bulletRigidbody;
    [SerializeField] private float _bulletSpeed;
    [SerializeField] private float _bulletLifetime;
    [SerializeField] private int _bulletDamage;

    private void OnEnable()
    {
        StartCoroutine(LifeTimeDeactivate());
    }

    private void OnDisable()
    {
        StopCoroutine(LifeTimeDeactivate());
    }

    private IEnumerator LifeTimeDeactivate()
    {
        yield return new WaitForSeconds(_bulletLifetime);
        DeactivateBullet();
    }

    public void InitiateMovement(Vector3 direction)
    {
        _bulletRigidbody.velocity = direction * _bulletSpeed;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<IEnemy>(out var enemy))
        {
            enemy.TakeDamage(_bulletDamage);
            DeactivateBullet();
            return;
        }
        DeactivateBullet();
    }
    private void DeactivateBullet()
    {
        this.gameObject.SetActive(false);
    }
}