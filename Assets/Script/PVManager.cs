using UnityEngine;

public class PVManager : MonoBehaviour
{
    public int heart=3;
    public int life=3;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (heart < 1)
        {
            life -= 1;
        }
        if (life < 1)
        {

        }
    }
}
