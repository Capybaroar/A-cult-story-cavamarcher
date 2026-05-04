using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using Unity.VisualScripting.Dependencies.NCalc;


public class QTE : MonoBehaviour
{
    public GameObject UiBibleManager;
    public bool droite = false;
    public bool gauche = false;
    public bool haut = false;
    public bool bas = false;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()  
    {
    }

    private void OnStart_QTE()
    {
        UiBibleManager.SetActive(!UiBibleManager.activeInHierarchy);
    }

    public void OnQTE(InputValue iv)
    {
        var val = iv.Get<Vector2>();

        if(val.x>0 && val.y == 0)
        {
            droite = true;
            print("Droite");
        }
        if (val.y > 0 && val.x == 0)
        {
            haut = true;
            print("Haut");

        }
        if (val.x < 0 && val.y == 0)
        {
            gauche = true;
            print("Gauche");

        }
        if (val.y < 0 && val.x == 0)
        {
            bas = true;
            print("Bas");

        }
    }

}
