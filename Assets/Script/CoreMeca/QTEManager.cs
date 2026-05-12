using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.InputSystem.Controls;

public class QTEManager : MonoBehaviour
{
    public GameObject QTElvl1;
    [SerializeField]
    private QTEDisplay[] qteDisplay;
    [SerializeField]
    private QTE[] possibleQTEs;
    private List<QTE> selectedQTEs;
    public bool QTEIng = false;



    public bool QTEFORCE = false;
    public bool QTEFORCECondition = false;

    public bool QTEPSY = false;
    public bool QTEPSYCondition = false;

    public bool QTEFIRE = false;
    public bool QTEFIRECondition = false;


    //scotch
    private int currentQTE = -1;

    void Start()
    {
        //qteDisplay = GetComponentsInChildren<QTEDisplay>();
        selectedQTEs = new List<QTE>();

    }

    private void GenerateQTE()
    {
        for (int i = 0; i < qteDisplay.Length; i++)
        {
            int randomIndex = Random.Range(0, possibleQTEs.Length);
            selectedQTEs.Add(possibleQTEs[randomIndex]);

            qteDisplay[i].Reset();
            qteDisplay[i].DisplayQTE(selectedQTEs[i]);
        }

    }


    //A changer
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            LaunchQTE();
            QTEFORCECondition = true;
        }

        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            LaunchQTE();
            QTEFIRECondition = true;
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            LaunchQTE();
            QTEPSYCondition = true;
        }
    }

    private void LaunchQTE()
    {
        Time.timeScale = 0f;

        QTElvl1.SetActive(true);

        StartCoroutine(Anim());
        QTEIng = true;

        //Afficher les display QTE 
        //Lancer une animation
    }

    private IEnumerator Anim()
    {
        for (int i = 0; i < 15; i++)
        {
            Debug.Log(i.ToString());
            foreach (var qted in qteDisplay)
            {
                Debug.Log("JESUISLAAAAAAAAAA");
                var disp = possibleQTEs[Random.Range(0, possibleQTEs.Length)];
                qted.DisplayQTE(disp);
            }
            yield return new WaitForSecondsRealtime(.1f);
        }
        GenerateQTE();
        currentQTE = 0;
    }


    public void OnQTE(InputValue v)
    {
        print("hiiiii");
        if (currentQTE < 0)
        {
            return;
        }

        var currentSelected = selectedQTEs[currentQTE];
        var dir = v.Get<Vector2>().normalized;
        if (dir == currentSelected.value)
        {
            qteDisplay[currentQTE].ValidationFeedback();
            currentQTE++;
        }
        else
        {
            qteDisplay[currentQTE].FailFeedback();
            //currentQTE =-1;
            //echec
        }
        if (currentQTE >= selectedQTEs.Count)
        {
            currentQTE = -1;
            QTElvl1.SetActive(false);
            Time.timeScale = 1f;
            QTEIng = false;
            if (QTEFORCECondition)
            {
                QTEFORCE = true;
            }

            if (QTEFIRECondition)
            {
                QTEFIRE = true;
            }

            if (QTEPSYCondition)
            {
                QTEPSY = true;
            }
            //victoire sequence
        }
    }

}
