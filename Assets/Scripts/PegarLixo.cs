using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PegarLixo : MonoBehaviour
{
    public GameObject PegarBtn;

    public BotaoPegarLixo botaoPegarLixo;



    // Start is called before the first frame update
    void Start()
    {
        PegarBtn.SetActive(false);


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnButtonLixo()
    {
            Destroy(this.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PegarBtn.SetActive(true);
        botaoPegarLixo.ConfigurarBotao(gameObject);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        PegarBtn.SetActive(false);
        botaoPegarLixo.ConfigurarBotao(null);
    }
}
