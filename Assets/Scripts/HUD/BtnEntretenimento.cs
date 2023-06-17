using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BtnEntretenimento : MonoBehaviour
{
    public EntretenimentoManager EM;
    public GameManager GM;

    private Button buttonComponent;

    private void Awake()
    {
        EM = FindObjectOfType<EntretenimentoManager>();
        GM = FindObjectOfType<GameManager>();

        GM.buttonEntretenimento.GetComponent<Button>();

        buttonComponent = GM.buttonEntretenimento.GetComponent<Button>();

        buttonComponent.onClick.AddListener(OnButtonClick);

        GM.buttonEntretenimento.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            GM.buttonEntretenimento.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            GM.buttonEntretenimento.SetActive(false);
        }
    }

    public void OnButtonClick()
    {
        EM.FillBar();
        GM.dinheiro -= 8;

    }
}
