using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeKeeper : MonoBehaviour
{
    public float time = 0;

    private void Update()
    {
        time += Time.deltaTime;
    }
}
