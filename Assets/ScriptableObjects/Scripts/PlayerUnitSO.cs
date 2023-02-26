using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Player Unit", menuName = "Scriptable Objects/Player Unit")]
public class PlayerUnitSO : ScriptableObject
{
    [Header("Unit Stats")]
    public float health;
    public float damage;

    [Range(1,100)]
    public float attackSpeed;

    [Header("Bullet Stats")]
    public GameObject bulletPrefab;
    public float bulletSpeed;
    public float bulletLifetime;
}
