using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Slider ForceTimerBar;
    public Slider psytimerbar;
    public Slider firetimerbar;
    public Slider qteTimerBar;
    public float forcegameTime;
    public float firegameTime;
    public float psygameTime;
    public float QTEGameTime;
    public QTEManager qtemanager;
    public SpeedIncrease speedincrease;

    public bool StopForceTimer;
    public bool StopFireTimer;
    public bool StopPsyTimer;
    public bool StopQTETimer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (qtemanager.PowerUsing == true && qtemanager.QTEFORCE == true)
        {
            QTETimerForceTimerBar();
        }

        if (qtemanager.PowerUsing == true && qtemanager.QTEFIRE == true)
        {
            QTETimerFireTimerBar();
        }

        if (qtemanager.PowerUsing == true && qtemanager.QTEPSY == true)
        {
            QTETimerPsyTimerBar();
        }


        if (qtemanager.QTEIng == true)
        {
            Debug.Log("QTEIng est true, QTEGameTime = " + QTEGameTime);
            QTETimerQTETimerBar();
        }
    }

    public void PowerEND()
    {
        if (forcegameTime <= 0)
        {
            qtemanager.QTEFORCE = false;
        }
        if (firegameTime <= 0)
        {
            qtemanager.QTEFIRE = false;
        }
        if (psygameTime <= 0)
        {
            speedincrease.SpeedBack();
            qtemanager.QTEPSY = false;
        }

        // PowerUsing passe à false seulement si tous les pouvoirs sont terminés
        if (!qtemanager.QTEFORCE && !qtemanager.QTEFIRE && !qtemanager.QTEPSY)
        {
            qtemanager.PowerUsing = false;
        }
    }


    public void QTETimerForceTimerBar()
    {
        if (StopForceTimer) return;

        forcegameTime -= Time.deltaTime;
        if (forcegameTime <= 0)
        {
            forcegameTime = 0;
            StopForceTimer = true;
            PowerEND();
        }
        ForceTimerBar.value = forcegameTime;
    }

    public void ResetTimerForceTimerBar()
    {
        //GameTime = 8;

        forcegameTime = ForceTimerBar.maxValue;
        StopForceTimer = false;
        ForceTimerBar.value = forcegameTime;
    }

    public void QTETimerFireTimerBar()
    {
        if (StopFireTimer) return;

        firegameTime -= Time.deltaTime;
        if (firegameTime <= 0)
        {
            firegameTime = 0;
            StopFireTimer = true;
            PowerEND();
        }
        firetimerbar.value = firegameTime;
    }

    public void ResetTimerFireTimerBar()
    {

        firegameTime = firetimerbar.maxValue;
        StopFireTimer = false;
        firetimerbar.value = firegameTime;
    }



    public void QTETimerPsyTimerBar()
    {
        if (StopPsyTimer) return;

        psygameTime -= Time.deltaTime;
        if (psygameTime <= 0)
        {
            psygameTime = 0;
            StopPsyTimer = true;
            PowerEND();
        }
        psytimerbar.value = psygameTime;
    }

    public void ResetTimerPsyTimerBar()
    {
        //QTEGameTime = 3;

        psygameTime = psytimerbar.maxValue;
        StopPsyTimer = false;
        psytimerbar.value = psygameTime;
    }





    public void QTETimerQTETimerBar()
    {
        if (StopQTETimer) return;

        QTEGameTime -= Time.unscaledDeltaTime;
        if (QTEGameTime <= 0)
        {
            QTEGameTime = 0;
            StopQTETimer = true;
            qtemanager.Failqte();
        }
        qteTimerBar.value = QTEGameTime;
    }

    public void ResetTimerQTETimerBar()
    {
        //QTEGameTime = 3;

        QTEGameTime = qteTimerBar.maxValue;
        StopQTETimer = false;
        qteTimerBar.value = QTEGameTime;
    }

}
