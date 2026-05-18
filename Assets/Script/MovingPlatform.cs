using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public Vector2 moveDirection = new Vector2(1f, 0f); // (1,0) = horizontal, (1,1) = diagonale
    public float moveDistance = 3f;                     // distance parcourue dans chaque sens
    public float speed = 2f;
    public float waitTime = 0f;                         // pause aux extrémités (0 = pas de pause)

    private Vector3 startPosition;
    private float distanceTravelled = 0f;
    private bool goingForward = true;
    private bool waiting = false;
    private float waitTimer = 0f;

    void Start()
    {
        startPosition = transform.position;
        // On normalise la direction pour que la vitesse soit cohérente
        // peu importe l'angle choisi
        moveDirection = moveDirection.normalized;
    }

    void Update()
    {
        if (waiting)
        {
            waitTimer -= Time.deltaTime;
            if (waitTimer <= 0f)
            {
                waiting = false;
                goingForward = !goingForward;
            }
            return;
        }

        float move = speed * Time.deltaTime;

        if (goingForward)
        {
            transform.Translate(moveDirection * move);
            distanceTravelled += move;

            if (distanceTravelled >= moveDistance)
            {
                distanceTravelled = moveDistance;
                waiting = true;
                waitTimer = waitTime;
            }
        }
        else
        {
            transform.Translate(-moveDirection * move);
            distanceTravelled -= move;

            if (distanceTravelled <= 0f)
            {
                distanceTravelled = 0f;
                waiting = true;
                waitTimer = waitTime;
            }
        }
    }

    // Permet au joueur de suivre la plateforme sans glisser
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.transform.SetParent(transform);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.transform.SetParent(null);
        }
    }
}
