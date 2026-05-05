using System.Collections;
using System.Linq;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.InputSystem;

public class QTEactivation : MonoBehaviour
{
    public Sprite[] spritesTab;
    public SpriteRenderer MySpriteRenderer;
    public QTE CheckCondition;
    public float TimeQTEanimation;
    public bool QTEdonechoosing=false;

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
        if (CheckCondition.UiBibleManager.activeSelf == true)
        {
            CoroutineQTEanimation = StartCoroutine(Logtime());
            while (QTEdonechoosing != true)
            {
                QTEchoosingmanager();
            }
            StopCoroutine(CoroutineQTEanimation);
            
        }

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

}