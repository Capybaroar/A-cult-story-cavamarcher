using System.Collections.Generic;
using UnityEngine;

public class SETActiveQTE : MonoBehaviour
{
    public bool QTEkeys = false;
    public GameObject QTElvl;
    public Hold key;
    public bool Close_condition;
    public List<QTEactivation> QTEGameobject;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Touchcall();
    }

    public void Touchcall()
    {
        // only trigger once when the key is first pressed
        if (key.Touch_E && !QTEkeys)
        {
            QTEkeys = true;
            Activation();
            Debug.Log("qteactive");
            foreach (QTEactivation sc in QTEGameobject)
            {
                sc.Cor();
            }
            Debug.Log("qteactiveOUI");
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
            // reset so the QTE can be triggered again later
            QTEkeys = false;
        }
    }
}
