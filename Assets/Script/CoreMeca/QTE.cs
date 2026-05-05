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
    public QTEactivation trueAnswer;
    public bool done=false;
    public bool defeat=false;


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



    public void QTEAnswer()
    {
        if(trueAnswer.spritesTab[0] == true)
        {
            if (bas == true)
            {
                done = true;

            }
            else 
            {
                defeat = true;
            }

        }

        if(trueAnswer.spritesTab[1] == true)
        {
            if (haut == true)
            {
                done = true;

            }
            else 
            {
                defeat = true;
            }

        }

        if(trueAnswer.spritesTab[2] == true)
        {
            if (gauche == true)
            {
                done = true;

            }
            else 
            {
                defeat = true;
            }

        }

        if(trueAnswer.spritesTab[3] == true)
        {
            if (droite == true)
            {
                done = true;

            }
            else 
            {
                defeat = true;
            }

        }
    }

}
