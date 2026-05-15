using UnityEngine;
using UnityEngine.InputSystem;

public class Mouvement : MonoBehaviour
{
    public Transform myTransform;
    public Rigidbody2D rb;
    public float speed;
    public float JumpForce;
    public QTEManager QTEManager;
    public JumpCondition jump;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (QTEManager.QTEIng != true)
        {
            MCmouvemet();
        }
    }

    

    public void MCmouvemet()
    {
        if (Input.GetKey(KeyCode.A))
        {
            rb.linearVelocity = new Vector3(-speed, 0, 0);
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            rb.linearVelocity = new Vector3(speed, 0, 0);

        }

        if (Input.GetKeyDown(KeyCode.Space) && jump.jumpcondition == true)
        {
            rb.AddForce(new Vector3(0, JumpForce, 0));

        }
    }
}
