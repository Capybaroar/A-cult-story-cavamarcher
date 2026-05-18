using UnityEngine;

public class Spike : MonoBehaviour
{
    public float speed = 3f;
    public float extendDistance = 2f;
    public float waitTime = 1f;       // attente en haut
    public float waitTimeIn = 2f;     // attente en bas

    private Vector3 startPosition;
    private bool extending = true;
    private float distanceTravelled = 0f;
    private float waitTimer = 0f;
    private bool waiting = false;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        if (waiting)
        {
            waitTimer -= Time.deltaTime;
            if (waitTimer <= 0f)
            {
                waiting = false;
            }
            return;
        }

        if (extending)
        {
            float move = speed * Time.deltaTime;
            transform.Translate(Vector2.up * move);
            distanceTravelled += move;

            if (distanceTravelled >= extendDistance)
            {
                waiting = true;
                waitTimer = waitTime;
                extending = false;
            }
        }
        else
        {
            float move = speed * Time.deltaTime;
            transform.Translate(Vector2.down * move);
            distanceTravelled -= move;

            if (distanceTravelled <= 0f)
            {
                distanceTravelled = 0f;
                transform.position = startPosition;
                waiting = true;
                waitTimer = waitTimeIn;
                extending = true;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PVManager.Instance.loosingheartcondition = true;
        }
    }
}