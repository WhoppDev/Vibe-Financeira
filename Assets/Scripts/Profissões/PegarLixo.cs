using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PegarLixo : MonoBehaviour
{
    public BotaoPegarLixo botaoPegarLixo;
    private GameObject objetoLixo;

    private bool pegueioLixo = false;
    private Button buttonComponent;

    private EntretenimentoManager EM;
    private GameManager GM;

    void Awake()
    {
        EM = FindObjectOfType<EntretenimentoManager>();
        GM = FindObjectOfType<GameManager>();

        GM.lixoBtn.GetComponent<Button>();

        buttonComponent = GM.lixoBtn.GetComponent<Button>();

        buttonComponent.onClick.AddListener(OnButtonLixo);

        pegueioLixo = false;
    }

    public void OnButtonLixo()
    {

        gameObject.SetActive(false);

        if(pegueioLixo == false)
        {
            if (EM.valorEntretenimento <= 0.25)
            {
                GM.dinheiro += 5;
            }
            else
            {
                GM.dinheiro += 10;
            }
        }
        pegueioLixo = true;

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            GM.lixoBtn.SetActive(true);
            objetoLixo = other.gameObject;

            buttonComponent.onClick = new Button.ButtonClickedEvent();
            buttonComponent.onClick.AddListener(() => OnButtonLixo());
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            GM.lixoBtn.SetActive(false);
            objetoLixo = null;
            botaoPegarLixo = null;
        }
    }

}
