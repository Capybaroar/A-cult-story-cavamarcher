using UnityEngine;

public class HoldBox : MonoBehaviour
{
    public GameObject mybox;
    public Collider2D player;
    public bool holdcodition = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            holdcodition = true;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
