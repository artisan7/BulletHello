using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Bullet : MonoBehaviour
{
    private Rigidbody2D rb;
    private float damage = 0;
    private float speed = 0;

    #region Unity Methods
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<PlayerUnitController>(out PlayerUnitController unit))
        {
            unit.TakeDamage(damage);
            Destroy(gameObject);
        }
    }
    #endregion

    public void Setup(float damage, float speed, float lifetime)
    {
        this.damage = damage;

        rb.AddForce(transform.up * speed, ForceMode2D.Impulse);
        StartCoroutine(DespawnOnLifetimeEnd(lifetime));
    }

    private IEnumerator DespawnOnLifetimeEnd(float lifetime)
    {
        yield return new WaitForSecondsRealtime(lifetime);

        Destroy(gameObject);
    }
}
