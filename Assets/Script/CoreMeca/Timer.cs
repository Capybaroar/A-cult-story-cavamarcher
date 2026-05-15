using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Slider PowerTimerBar;
    public Slider qteTimerBar;
    public float GameTime;
    public float QTEGameTime;
    public QTEManager qtemanager;


    public bool StopPowerTimer;
    public bool StopQTETimer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (qtemanager.PowerUsing == true)
        {
            QTETimerPowerTimerBar();
        }
        PowerEND();

        if (qtemanager.QTEIng == true)
        {
            Debug.Log("QTEIng est true, QTEGameTime = " + QTEGameTime);
            QTETimerQTETimerBar();
        }
    }

    public void PowerEND()
    {
        if (GameTime <= 0)
        {
            qtemanager.PowerUsing = false;
            qtemanager.QTEFORCE = false;
            qtemanager.QTEFIRE = false;
            qtemanager.QTEPSY = false;
        }

    }


    public void QTETimerPowerTimerBar()
    {
        if (StopPowerTimer) return;

        GameTime -= Time.deltaTime;
        if (GameTime <= 0)
        {
            GameTime = 0;
            StopPowerTimer = true;
        }
        PowerTimerBar.value = GameTime;
    }

    public void ResetTimerPowerTimerBar()
    {
        //GameTime = 8;

        GameTime = PowerTimerBar.maxValue;
        StopPowerTimer = false;
        PowerTimerBar.value = GameTime;
    }





    public void QTETimerQTETimerBar()
    {
        if (StopQTETimer) return;

        QTEGameTime -= Time.unscaledDeltaTime;
        if (QTEGameTime <= 0)
        {
            QTEGameTime = 0;
            StopQTETimer = true;
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
