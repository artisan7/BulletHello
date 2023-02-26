using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerUnitController : MonoBehaviour
{
    [SerializeField] private PlayerUnitSO unit;
    [SerializeField] List<MuzzleController> muzzles;

    private float health;
    private Rigidbody2D rb;

    private void Awake()
    {
        health = unit.health;
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        foreach (MuzzleController muzzle in muzzles)
        {
            muzzle.Setup(20 / unit.attackSpeed, unit.bulletPrefab, unit.damage, unit.bulletSpeed, unit.bulletLifetime);
        }
    }

    public void TakeDamage(float damage)
    {
        health -= damage;

        if (health <= 0)
        {
            rb.isKinematic = false;
            GetComponent<SpriteRenderer>().color = Color.red;
        }
    }


}
