using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

public class QTEManager : MonoBehaviour
{
    public GameObject QTEBox;
    public List<GameObject> QTElist;
    public QTE IsDone;
    public GameObject QTEStart;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        print("hihi");
    }

    // Update is called once per frame
    void Update()
    {
        int var = 0
        If (QTElist(var).IsDone.done == true)
        {
            QTElist(var).SetActive(false);
        }
        var += 1;
        if (QTElist(3).activeSelf(false))
        {
            var=0;
            QTEStart.SetActive(false);
            foreach (go in QTElist)
            {
                go.SetActive(true);
            }


        }
    }
}
