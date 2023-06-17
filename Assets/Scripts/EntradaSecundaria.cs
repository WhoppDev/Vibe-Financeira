using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EntradaSecundaria : MonoBehaviour
{
    public string cena;

    public Transform teleportPoint; // Ponto de teletransporte
    private Button button; // Alteração: alterado o tipo da variável para Button
    private bool canEnterScene = false;

    private void Awake()
    {
        button = GameObject.Find("BtnEntrar").GetComponent<Button>(); // Alteração: atribuído o componente Button ao botão

        button.onClick.AddListener(OnButtonClick); // Alteração: atribuído o método OnButtonClick ao evento de clique do botão

        // Procura o objeto "Entrada" na cena
        GameObject entradaObj = GameObject.Find("Entrada");

        if (entradaObj != null)
        {
            // Obtém a referência do Transform do objeto "Entrada"
            teleportPoint = entradaObj.transform;
        }
        else
        {
            Debug.LogError("Objeto de entrada não encontrado na cena.");
        }
    }

    void Start()
    {
        // Verifica se o jogador está presente na cena
        if (GameObject.FindWithTag("Player") != null)
        {
            // Obtém a referência do objeto do jogador
            GameObject player = GameObject.FindWithTag("Player");

            // Verifica se o ponto de teletransporte foi encontrado
            if (teleportPoint != null)
            {
                // Teletransporta o jogador para o ponto desejado
                player.transform.position = teleportPoint.position;
            }
            else
            {
                Debug.LogError("Ponto de teletransporte não encontrado.");
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
