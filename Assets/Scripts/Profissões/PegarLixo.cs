using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PegarLixo : MonoBehaviour
{
    public GameObject PegarBtn;
    public Button button;
    public BotaoPegarLixo botaoPegarLixo;
    private GameObject objetoLixo;

    private bool pegueioLixo = false;

    private EntretenimentoManager EM;
    private GameManager gm;

    void Start()
    {
        EM = FindObjectOfType<EntretenimentoManager>();
        gm = FindObjectOfType<GameManager>();
        pegueioLixo = false;
    }

    public void OnButtonLixo()
    {

        gameObject.SetActive(false);

        if(pegueioLixo == false)
        {
            if (EM.valorEntretenimento <= 0.25)
            {
                gm.dinheiro += 5;
            }
            else
            {
                gm.dinheiro += 10;
            }
        }
        pegueioLixo = true;

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PegarBtn.SetActive(true);
            objetoLixo = other.gameObject;
            botaoPegarLixo = PegarBtn.GetComponent<BotaoPegarLixo>();

            button.onClick = new Button.ButtonClickedEvent();
            button.onClick.AddListener(() => OnButtonLixo());
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PegarBtn.SetActive(false);
            objetoLixo = null;
            botaoPegarLixo = null;
        }
    }

}
