using System.Collections;
using System.Linq;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class QTEactivation : MonoBehaviour
{
    public Sprite[] spritesTab;
    public SpriteRenderer MySpriteRenderer;
    public float TimeQTEanimation;
    public bool QTEdonechoosing=false;
    public bool droite = false;
    public bool gauche = false;
    public bool haut = false;
    public bool bas = false;
    public bool done = false;
    public bool defeat = false;


    private Coroutine CoroutineQTEanimation;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {


    }


    public void Cor()
    {
       
        CoroutineQTEanimation = StartCoroutine(Logtime());
        while (QTEdonechoosing != true)
        {
            QTEchoosingmanager();
        }
        StopCoroutine(CoroutineQTEanimation);
            
       

    }

    public IEnumerator Logtime()
    {
        yield return new WaitForSeconds(TimeQTEanimation);
        QTEdonechoosing = true;
    }

    public void QTEchoosingmanager()
    {
        var val = Random.Range(0, spritesTab.Count());
        MySpriteRenderer.sprite = spritesTab[val];
    }


    public void OnQTE(InputValue iv)
    {
        var val = iv.Get<Vector2>();

        if (val.x > 0 && val.y == 0)
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
        if (spritesTab[0] == true)
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

        if (spritesTab[1] == true)
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

        if (spritesTab[2] == true)
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

        if (spritesTab[3] == true)
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