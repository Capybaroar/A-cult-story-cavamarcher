using UnityEngine;

public class SETActiveQTE : MonoBehaviour
{
    public bool QTEkeys=false;
    public GameObject QTElvl;
    public Hold key;
    public bool Close_condition;
    public QTEactivation QTEactivation;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(key.Touch_E == true)
        {
            QTEkeys = true;
            Activation();
            QTEactivation.Cor();

        }
    }


    public void Activation()
    {
        if (QTElvl.activeSelf == false && QTEkeys == true)
        {
            Debug.Log("maismarche");
            QTElvl.SetActive(true);
        }
        if (Close_condition == true)
        {
            QTElvl.SetActive(false);

        }
    }
}
