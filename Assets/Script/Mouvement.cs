using UnityEngine;
using UnityEngine.InputSystem;

public class Mouvement : MonoBehaviour
{
    public Transform myTransform;
    public Rigidbody2D rb;
    public float speed;
    public Raycast Jump;
    public float JumpForce;
    public QTEManager QTEManager;

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
            myTransform.position = myTransform.position - new Vector3(speed, 0, 0);
        }

        if (Input.GetKey(KeyCode.D))
        {
            myTransform.position = myTransform.position + new Vector3(speed, 0, 0);

        }

        if (Input.GetKeyDown(KeyCode.Space) && Jump.JumpCondition)
        {
            rb.AddForce(new Vector2(0, JumpForce) * 5);

        }
    }
}
