using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EntradaPrefeitura : MonoBehaviour
{
    public string cena;
    private ClockUI clockUI;
    public float time;
    public int closeTime;
    public GameObject foraDeFuncionamentoPanel;

    private void Awake()
    {
        clockUI = FindObjectOfType<ClockUI>();
        foraDeFuncionamentoPanel.SetActive(false);
    }

    // Start is called before the first frame update
    void Update()
    {
        if (clockUI != null)
        {
            time = clockUI.dayTime;
        }


    }

    void OnTriggerEnter2D(Collider2D Entrada)
    {
        if (time <= closeTime)
        {

            if (Input.GetKeyDown(KeyCode.F))
            {
                SceneManager.LoadScene(cena);
                foraDeFuncionamentoPanel.SetActive(false);
            }
        }
        else
        {
            foraDeFuncionamentoPanel.SetActive(true);
        }

    }

    public void ExitPanel()
    {
        foraDeFuncionamentoPanel.SetActive(false);
    }
}
