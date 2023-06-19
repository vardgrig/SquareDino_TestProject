using UnityEngine;

public class BulletPool : MonoBehaviour
{
    [SerializeField] private int bulletPoolCount;
    [SerializeField] private bool autoExpandBulletPool;
    [SerializeField] private Bullet bulletPrefab;
    [SerializeField] private Transform shootingOrigin;

    private PoolSystem<Bullet> bulletPool;

    void Start()
    {
        this.bulletPool = new PoolSystem<Bullet>(this.bulletPrefab, this.bulletPoolCount, this.transform.transform, this.autoExpandBulletPool);
    }

    public void ShootBullet(Vector3 targetPosition)
    {
        var bullet = bulletPool.GetFreeelement();
        if (bullet != null)
        {
            bullet.transform.position = shootingOrigin.position;
            Vector3 direction = (targetPosition - bullet.transform.position).normalized;
            var bulletComponent = bullet.GetComponent<Bullet>();
            bulletComponent.InitiateMovement(direction);
        }
    }
}
