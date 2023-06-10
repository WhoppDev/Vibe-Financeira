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
