using UnityEngine;

public class Hold : MonoBehaviour
{
    public BoxInterac CheckUp;
    public Transform playerTransform;
    public Vector3 holdOffset = new Vector3(0f, 1.5f, 0f);
    public Collider2D playerCollider; // Glisse le collider du joueur ici dans l'inspecteur

    private bool isHeld = false;
    public bool Touch_E;
    private Rigidbody2D rb;
    private Collider2D boxCollider;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<Collider2D>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {

            if (!isHeld && CheckUp.InteracCondition)
            {
                Touch_E = true;
                rb.bodyType = RigidbodyType2D.Kinematic;
                rb.linearVelocity = Vector2.zero;
                Physics2D.IgnoreCollision(boxCollider, playerCollider, true); // d�sactive la collision
                isHeld = true;
            }
            else if (isHeld)
            {
                rb.bodyType = RigidbodyType2D.Dynamic;
                Physics2D.IgnoreCollision(boxCollider, playerCollider, false); // r�active la collision
                isHeld = false;
            }
        }

    }

    void FixedUpdate()
    {
        if (isHeld)
        {
            rb.MovePosition(new Vector2(
                playerTransform.position.x + holdOffset.x,
                playerTransform.position.y + holdOffset.y
            ));
        }
    }
}