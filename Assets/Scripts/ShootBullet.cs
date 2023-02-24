using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootBullet : MonoBehaviour
{
    [Header("Shooting")]
    [SerializeField] private float attackInterval;

    [Header("Bullet")]
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float bulletDamage;
    [SerializeField] private float bulletSpeed;
    [SerializeField] private float bulletLifetime;

    private void Start()
    {
        StartCoroutine(Shoot());
    }

    private IEnumerator Shoot()
    {
        while(true)
        {
            yield return new WaitForSecondsRealtime(attackInterval);

            // Spawn Bullet
            Bullet b = Instantiate(bulletPrefab, transform.position, transform.rotation).GetComponent<Bullet>();
            b.Setup(bulletDamage, bulletSpeed, bulletLifetime);
        };
    }
}
