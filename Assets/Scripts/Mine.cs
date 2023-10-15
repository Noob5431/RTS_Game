using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mine : MonoBehaviour
{
    public GameObject timeKeeperobj, resourceManager;
    public int resourceIndex;
    public bool worked;
    public int yield;
    public LayerMask friendlyLayer;
    public float mineRadius;
    bool working = false;

    private void Update()
    {
        Collider2D worker = Physics2D.OverlapCircle(transform.position, mineRadius, friendlyLayer);
        if (worker && worker.GetComponent<Unit>().worker)
        {
            worked = true;
        }
        else worked = false;
        if (worked && !working)
        {
            StartCoroutine(Mine1());
        }
    }
    IEnumerator Mine1 ()
    {
        working = true;
        float startTime = timeKeeperobj.GetComponent<TimeKeeper>().time;
        while(timeKeeperobj.GetComponent<TimeKeeper>().time - startTime < 1)
        {
            yield return null;
        }
        switch(resourceIndex)
        {
            case 0:
                resourceManager.GetComponent<resurse>()._noobomium += yield;
                break;
            case 1:
                resourceManager.GetComponent<resurse>()._naturalium += yield;
                break;
            case 2:
                resourceManager.GetComponent<resurse>()._taranium += yield;
                break;
            case 3:
                resourceManager.GetComponent<resurse>()._weed += yield;
                break;
        }
        working = false;
    }
}
