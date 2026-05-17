using UnityEngine;

public class SpeedIncrease : MonoBehaviour
{
    public Mouvement mouvement;
    public float speedboost;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void SpeedBoost()
    {
        mouvement.speed *= speedboost;
    }

    public void SpeedBack()
    {
        mouvement.speed = mouvement.speed / speedboost;
    }


}
