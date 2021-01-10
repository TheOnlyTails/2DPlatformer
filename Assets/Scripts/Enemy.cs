using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health = 100;
    public GameObject deathEffect;

    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        var localDeathEffect = Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(localDeathEffect, 0.417f);
        Destroy(gameObject);
    }
}
