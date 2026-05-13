using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Slider TimerSlider;
    public float GameTime;
    public QTEManager qtemanager;

   
    public bool Stoptimer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (qtemanager.PowerUsing == true)
        {
            QTETimer();
        }
    }

    public void QTETimer()
    {

        float time = GameTime - Time.deltaTime;

        if (time <= 0)
        {
            Stoptimer = true;
        }

        if (Stoptimer == false)
        {
            TimerSlider.value = time;

        }
    }

}
