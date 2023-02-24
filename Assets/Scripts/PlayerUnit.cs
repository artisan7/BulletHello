using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerUnit : MonoBehaviour
{
    [SerializeField] private float health;

    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
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
