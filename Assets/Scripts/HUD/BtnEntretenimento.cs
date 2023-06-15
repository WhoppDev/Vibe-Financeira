using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnEntretenimento : MonoBehaviour
{
    public GameObject entretenimentoBtn;
    private EntretenimentoManager EM;

    private void Start()
    {
        EM = FindObjectOfType<EntretenimentoManager>();
        entretenimentoBtn.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            entretenimentoBtn.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            entretenimentoBtn.SetActive(false);
        }
    }

    public void OnButtonClick()
    {
        EM.FillBar();
    }
}
