using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class QTEManager : MonoBehaviour
{
    public GameObject QTElvl1;
    [SerializeField]
    private QTEDisplay[] qteDisplay;
    [SerializeField]
    private QTE[] possibleQTEs;
    private List<QTE> selectedQTEs;
    public bool QTEIng = false;

    public PVManager pvmanager;
    public Timer timer;

    public GameObject forceflouqte;
    public GameObject fireflouqte;
    public GameObject psyflouqte;


    public bool QTEFORCE = false;
    public bool QTEFORCECondition = false;

    public bool QTEPSY = false;
    public bool QTEPSYCondition = false;

    public bool QTEFIRE = false;
    public bool QTEFIRECondition = false;

    public bool PowerUsing = false;

    private int currentQTE = -1;

    // Référence à la coroutine d'échec pour pouvoir l'arrêter proprement (Bug #3)
    private Coroutine _failCoroutine;
    public bool failqte=false;

    void Start()
    {
        selectedQTEs = new List<QTE>();
    }

    private void GenerateQTE()
    {
        for (int i = 0; i < qteDisplay.Length; i++)
        {
            int randomIndex = UnityEngine.Random.Range(0, possibleQTEs.Length);

            selectedQTEs.Add(possibleQTEs[randomIndex]);

            qteDisplay[i].Reset();
            qteDisplay[i].DisplayQTE(selectedQTEs[i]);
        }
    }

    void Update()
    {
        TouchManager();
    }

    private void TouchManager()
    {
        if (PowerUsing != true && QTEIng != true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                forceflouqte.SetActive(true);
                timer.ResetTimerQTETimerBar();
                LaunchQTE();
                QTEFORCECondition = true;
            }

            if (Input.GetKeyDown(KeyCode.Mouse1))
            {
                fireflouqte.SetActive(true);

                timer.ResetTimerQTETimerBar();

                LaunchQTE();
                QTEFIRECondition = true;
            }

            if (Input.GetKeyDown(KeyCode.Q))
            {
                psyflouqte.SetActive(true);

                timer.ResetTimerQTETimerBar();

                LaunchQTE();
                QTEPSYCondition = true;
            }
        }
    }

    private void LaunchQTE()
    {
        Time.timeScale = 0f;
        QTEIng = true;


        QTElvl1.SetActive(true);

        StartCoroutine(Anim());
    }

    private IEnumerator Anim()
    {
        for (int i = 0; i < 15; i++)
        {
            foreach (var qted in qteDisplay)
            {
                var disp = possibleQTEs[UnityEngine.Random.Range(0, possibleQTEs.Length)];
                qted.DisplayQTE(disp);
            }
            yield return new WaitForSecondsRealtime(.1f);
        }
        selectedQTEs.Clear();

        GenerateQTE();
        currentQTE = 0;
    }

    private IEnumerator FailQTETime()
    {
        yield return new WaitForSecondsRealtime(1f);
        // La coroutine se termine naturellement, plus besoin de StopCoroutine ici (Bug #3)
    }





    public void OnQTE(InputValue v)
    {
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
            Failqte();
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
                QTEFORCECondition = false;

                PowerUsing = true;

                timer.ResetTimerPowerTimerBar();
                forceflouqte.SetActive(false);

            }

            if (QTEFIRECondition)
            {
                QTEFIRE = true;
                QTEFIRECondition = false;

                PowerUsing = true;

                timer.ResetTimerPowerTimerBar();
                fireflouqte.SetActive(false);



            }

            if (QTEPSYCondition)
            {
                QTEPSY = true;
                QTEPSYCondition = false;

                PowerUsing = true;

                timer.ResetTimerPowerTimerBar();
                psyflouqte.SetActive(false);

            }
        }
    }


    public void Failqte()
    {
        // Bug #3 — on arrête proprement l'ancienne coroutine avant d'en lancer une nouvelle
        if (_failCoroutine != null) StopCoroutine(_failCoroutine);
        _failCoroutine = StartCoroutine(FailQTETime());

        qteDisplay[currentQTE].FailFeedback();
        QTElvl1.SetActive(false);
        pvmanager.loosingheartcondition = true;
        QTEFORCECondition = false;
        QTEFIRECondition = false;
        QTEPSYCondition = false;

        // Bug #4 — on remet le temps en marche après un échec
        Time.timeScale = 1f;
        QTEIng = false;

        // Bug #5 — on réinitialise currentQTE pour éviter un accès invalide
        currentQTE = -1;


        return;
    }
}
