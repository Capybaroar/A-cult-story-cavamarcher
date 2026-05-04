using UnityEngine;

public class Raycast : MonoBehaviour
{
    // Float a rigidbody object a set distance above a surface.

    public bool JumpCondition;
    public LayerMask layerMask; 

    Rigidbody2D rb2D;


    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        // Cast a ray straight down.
        var distanceact = Physics2D.Raycast(transform.position, -Vector2.up,0.2f,layerMask);

        // If it hits something...
        if (distanceact)
        {
            JumpCondition = true;
        }

        else
        {
            
            JumpCondition = false;
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawRay(transform.position, -Vector2.up * 0.2f);
    }
}