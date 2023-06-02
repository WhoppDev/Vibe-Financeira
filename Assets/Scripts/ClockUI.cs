using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockUI : MonoBehaviour
{
    public float dayTime;
    public int dayCount;

    private void Start()
    {
        dayCount = 0;
        dayTime = 0;
    }

    private void Update()
    {
        dayTime += Time.deltaTime;

        if(dayTime >= 24)
        {
            dayTime = 0;
            dayCount++;
        }
        transform.localEulerAngles = Vector3.forward * ((360 * dayTime) / 24) * -1;

    }
}
