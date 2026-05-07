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
    public bool QTEdonechoosing = false;
    public bool droite = false;
    public bool gauche = false;
    public bool haut = false;
    public bool bas = false;
    public bool done = false;
    public bool defeat = false;
    public bool NotMyTurn=true;


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
        if (CoroutineQTEanimation != null) return;

        print("corui");
        // start the timeout coroutine
        CoroutineQTEanimation = StartCoroutine(Logtime());
        // start the non-blocking choosing loop
        StartCoroutine(QTEChoosingLoop());
    }

    private IEnumerator QTEChoosingLoop()
    {
        while (!QTEdonechoosing)
        {
            QTEchoosingmanager();
            // allow one frame to pass so coroutine, input, and rendering continue
            yield return null;
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


    public void QTEInput()
    {
        if (NotMyTurn == false)
        {

            if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
            {
                droite = true;
                print("Droite");
            }
            if (Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.UpArrow))
            {
                haut = true;
                print("Haut");

            }
            if (Input.GetKeyDown(KeyCode.Q) || Input.GetKeyDown(KeyCode.LeftArrow))
            {
                gauche = true;
                print("Gauche");

            }
            if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
            {
                bas = true;
                print("Bas");

            }
        }
    }



    public void QTEAnswer()
    {
        if (spritesTab[0] == true)
        {
            if (bas == true)
            {
                done = true;
                print("Answer correct");

            }
            else
            {
                defeat = true;
                print("Answer false");
            }

        }

        if (spritesTab[1] == true)
        {
            if (haut == true)
            {
                done = true;
                print("Answer correct");

            }
            else
            {
                defeat = true;
                print("Answer false");
            }

        }

        if (spritesTab[2] == true)
        {
            if (gauche == true)
            {
                done = true;
                print("Answer correct");

            }
            else
            {
                defeat = true;
                print("Answer false");
            }

        }

        if (spritesTab[3] == true)
        {
            if (droite == true)
            {
                done = true;
                print("Answer correct");

            }
            else
            {
                defeat = true;
                print("Answer false");
            }

        }
    }
}