using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EntradaSecundaria : MonoBehaviour
{
    public string cena;

    public Transform teleportPoint; // Ponto de teletransporte
    private Button button; // Altera��o: alterado o tipo da vari�vel para Button
    private bool canEnterScene = false;

    private void Awake()
    {
        button = GameObject.Find("BtnEntrar").GetComponent<Button>(); // Altera��o: atribu�do o componente Button ao bot�o

        button.onClick.AddListener(OnButtonClick); // Altera��o: atribu�do o m�todo OnButtonClick ao evento de clique do bot�o

        // Procura o objeto "Entrada" na cena
        GameObject entradaObj = GameObject.Find("Entrada");

        if (entradaObj != null)
        {
            // Obt�m a refer�ncia do Transform do objeto "Entrada"
            teleportPoint = entradaObj.transform;
        }
        else
        {
            Debug.LogError("Objeto de entrada n�o encontrado na cena.");
        }
    }

    void Start()
    {
        // Verifica se o jogador est� presente na cena
        if (GameObject.FindWithTag("Player") != null)
        {
            // Obt�m a refer�ncia do objeto do jogador
            GameObject player = GameObject.FindWithTag("Player");

            // Verifica se o ponto de teletransporte foi encontrado
            if (teleportPoint != null)
            {
                // Teletransporta o jogador para o ponto desejado
                player.transform.position = teleportPoint.position;
            }
            else
            {
                Debug.LogError("Ponto de teletransporte n�o encontrado.");
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            canEnterScene = true;
            button.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            canEnterScene = false;
            button.gameObject.SetActive(false);
        }
    }

    public void OnButtonClick()
    {
        if (canEnterScene)
        {
            SceneManager.LoadScene(cena);
        }
    }
}
