using UnityEngine;

public class JumpCondition : MonoBehaviour
{
    public bool jumpcondition = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        jumpcondition = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        jumpcondition = false;

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
