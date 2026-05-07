using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

public class QTEManager : MonoBehaviour
{
    public GameObject QTEBox;
    public List<GameObject> QTElist;
    public QTEactivation qteactivation;
    public GameObject QTEStart;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        int var = 0;
        var qtea = QTElist[var].GetComponent<QTEactivation>();
        qtea.NotMyTurn = false;
        if (qtea.done == true)
        {
            QTElist[var].SetActive(false);
            var += 1;

        }

        if (!QTElist[3].activeSelf)
        {
            var = 0;
            QTEStart.SetActive(false);
            foreach (GameObject go in QTElist)
            {
                go.SetActive(true);
            }


        }
    }
}
