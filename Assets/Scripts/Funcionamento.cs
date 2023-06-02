using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Funcionamento : MonoBehaviour
{
    private ClockUI clockUI;
    private float time;
    public GameObject exitPanel;
    public int closeTime;

    private void Awake()
    {
        clockUI = FindObjectOfType<ClockUI>();
        if (clockUI == null)
        {
            Debug.LogError("ClockUI não encontrado.");
        }
    }

    void Start()
    {
        exitPanel.SetActive(false);

    }

    private void Update()
    {
        if (clockUI != null)
        {
            time = clockUI.dayTime;

            if (time >= closeTime)
            {
                exitPanel.SetActive(true);
            }
        }
    }
}
