using System.Net;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [HideInInspector]
    public Transform player;        // assigné automatiquement par WaveManager
    public float speed = 5f;
    public PVManager pvmanager;

    private void Start()
    {
    }
    void Update()
    {
        MoveTowardsPlayer();
    }

    private void MoveTowardsPlayer()
    {
        if (player == null) return;

        // L'ennemi suit la hauteur Y du joueur en temps réel et avance vers la gauche
        Vector3 target = new Vector3(player.position.x, player.position.y, 0f);
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Le joueur perd une vie
            PVManager.Instance.loosingheartcondition = true;

            // L'ennemi se détruit après avoir touché le joueur
            Destroy(gameObject);
        }
    }
}
