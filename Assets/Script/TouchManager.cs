using UnityEngine;

public class TouchManager : MonoBehaviour
{
    public bool TouchAppear = false;
    public bool E_Key=false;
    public Sprite E_Touch;
    public SpriteRenderer MySprite;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    public void Touchmanager()
    {
        if (TouchAppear == true)
        {
            print("setactive");
            GetComponent<Renderer>().enabled = true;
            if (E_Key == true)
            {
                print("EEEEE");
                MySprite.sprite = E_Touch;
            }
        }
        else
        {
            GetComponent<Renderer>().enabled = false;

        }

    }

    // Update is called once per frame
    void Update()
    {
        Touchmanager();
    }
}
