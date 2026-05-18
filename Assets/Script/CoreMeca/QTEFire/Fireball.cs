using UnityEngine;

public class Fireball : MonoBehaviour
{
    private Rigidbody2D rb;
    public float lifetime = 3f; // la boule disparait après 3 secondes

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        // On désactive la gravité pour que la boule vole en ligne droite
        rb.gravityScale = 0f;
    }

    public void Launch(float direction, float speed)
    {
        rb.linearVelocity = new Vector2(direction * speed, 0f);

        // On retourne le sprite de la boule si elle va à gauche
        if (direction < 0)
        {
            transform.localScale = new Vector2(-1f, 1f);
        }

        // La boule se détruit automatiquement après lifetime secondes
        Destroy(gameObject, lifetime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) return;

        // Si on touche un ennemi on le détruit
        if (collision.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);
        }

        Destroy(gameObject);
    }
}
