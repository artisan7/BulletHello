using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuzzleController : MonoBehaviour
{
    [HideInInspector] public float AttackInterval { get; private set; }
    [HideInInspector] public GameObject BulletPrefab { get; private set; }
    [HideInInspector] public float BulletDamage { get; private set; }
    [HideInInspector] public float BulletSpeed { get; private set; }
    [HideInInspector] public float BulletLifetime { get; private set; }

    private bool isShooting = false;

    public void Setup(float attackInterval, GameObject bulletPrefab, float bulletDamage, float bulletSpeed, float bulletLifetime)
    {
        AttackInterval = attackInterval;
        BulletPrefab = bulletPrefab;
        BulletDamage = bulletDamage;
        BulletSpeed = bulletSpeed;
        BulletLifetime = bulletLifetime;

        if (!isShooting)
        {
            isShooting = true;
            StartCoroutine(Shoot());
        }
    }

    public IEnumerator Shoot()
    {
        while(true)
        {
            yield return new WaitForSecondsRealtime(AttackInterval);

            // Spawn Bullet
            Bullet b = Instantiate(BulletPrefab, transform.position, transform.rotation).GetComponent<Bullet>();
            b.Setup(BulletDamage, BulletSpeed, BulletLifetime);
        };
    }
}
