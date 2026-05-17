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
            print("left");
            rb.linearVelocity = new Vector2(-speed, rb.linearVelocity.y);
        }

        else if (Input.GetKey(KeyCode.D))
        {
            rb.linearVelocity = new Vector2(speed, rb.linearVelocity.y);

        }

        else
        {
            // Amélioration — quand aucune touche n'est appuyée, le joueur s'arrête
            // sans toucher à Y pour garder la gravité et le saut intacts
            rb.linearVelocity = new Vector2(0, rb.linearVelocity.y);
        }

        if (Input.GetKeyDown(KeyCode.Space) && jump.jumpcondition == true)
        {
            // Amélioration — on remet Y à 0 avant d'appliquer la force
            // pour que le saut soit toujours de la même hauteur
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, 0);
            rb.AddForce(new Vector2(0, JumpForce), ForceMode2D.Impulse);
        }
    }
}
