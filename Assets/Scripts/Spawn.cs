using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject worldCenter, resourceManager;
    bool able = true;

    public void spawn()
    {
        able = true;
        GameObject initialClone = worldCenter.GetComponent<ClickManager>().selected[0].transform.Find("unit").gameObject;
        for (int i = 0; i < 4; i++)
        {
            if (resourceManager.GetComponent<resurse>()._noobomium < initialClone.GetComponent<Unit>().cost[0] ||
                resourceManager.GetComponent<resurse>()._naturalium < initialClone.GetComponent<Unit>().cost[1] ||
                resourceManager.GetComponent<resurse>()._taranium < initialClone.GetComponent<Unit>().cost[2] ||
                resourceManager.GetComponent<resurse>()._weed < initialClone.GetComponent<Unit>().cost[3])
            {
                able = false;
            }
        }
        if (able)
        {
            GameObject clone = Instantiate(initialClone, initialClone.transform.position, initialClone.transform.rotation);
            resourceManager.GetComponent<resurse>()._noobomium -= initialClone.GetComponent<Unit>().cost[0];
            resourceManager.GetComponent<resurse>()._naturalium -= initialClone.GetComponent<Unit>().cost[1];
            resourceManager.GetComponent<resurse>()._taranium -= initialClone.GetComponent<Unit>().cost[2];
            resourceManager.GetComponent<resurse>()._weed -= initialClone.GetComponent<Unit>().cost[3];
            clone.SetActive(true);
        }
    }

    public void CreateBuilding(string id)
    {
        GameObject initialClone = worldCenter.GetComponent<ClickManager>().selected[0].transform.Find(id).gameObject;
        Instantiate(initialClone).SetActive(true);
    }
}
