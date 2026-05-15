using UnityEngine;

public class BoxInterac : MonoBehaviour
{
    public bool InteracCondition;
    public LayerMask layerMask;
    public Rigidbody2D rb2D;
    public TouchManager CheckCondition;
    public QTEManager qtemanager;

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        qtemanager = FindFirstObjectByType<QTEManager>();
        CheckCondition = FindFirstObjectByType<TouchManager>();
    }

    void FixedUpdate()
    {
        var distanceactRight = Physics2D.Raycast(transform.position, Vector2.right, 1f, layerMask);
        var distanceactLeft = Physics2D.Raycast(transform.position, -Vector2.right, 1f, layerMask);

        if (qtemanager.QTEFORCE == true)
        {
            if (distanceactRight || distanceactLeft)
            {
                InteracCondition = true;
                CheckCondition.TouchAppear = true;
                print("YIPIiiiiiiiii");
                CheckCondition.E_Key = true;


            }
            else
            {
                InteracCondition = false;
                CheckCondition.TouchAppear = false;
                CheckCondition.E_Key = false;
            }
        }


    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.purple;
        Gizmos.DrawRay(transform.position, -Vector2.right * 1f);
        Gizmos.DrawRay(transform.position, Vector2.right * 1f);
    }
}