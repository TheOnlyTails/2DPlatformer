using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;
    public Rigidbody2D rigidBody;
    public int damage = 30;
    public GameObject impactEffect;

    private void Start()
    {
        rigidBody.velocity = transform.right * speed;
    }

    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        var enemy = hitInfo.GetComponent<Enemy>();

        if (enemy != null)
        {
            enemy.TakeDamage(damage);
        }

        // ReSharper disable once Unity.InefficientPropertyAccess
        var localImpactEffect = Instantiate(impactEffect, transform.position, transform.rotation);

        Destroy(gameObject);

        Destroy(localImpactEffect, 0.333f);
    }
}
