using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogControl : MonoBehaviour
{
    [Header("Componentes")]
    public GameObject dialogueObj;
    public Image profile;
    public Text speech;

    public GameObject Sair;

    public GameObject HUD;
    public GameObject GameController;
    public GameObject playerController;

    private int index;
    private string[] sentence;
    private Dialog dialog;

    private GameManager GM;

    private void Awake()
    {
        GM = FindObjectOfType<GameManager>();
    }


    public void Start()
    {
        if(GM.intro == false)
        {
            HUD.SetActive(false);
            playerController.SetActive(false);
            GameController.SetActive(false);
            dialog = FindObjectOfType<Dialog>();
            Sair.SetActive(false);

            string playerNickname = PlayerData.instance.playerNickname;
            Speech(playerNickname);
        }
        else
        {
            dialogueObj.SetActive(false);
        }

    }

    public void Speech(string playerNickname)
    {
        dialogueObj.SetActive(true);
        sentence = dialog.speechTxt;
        StartCoroutine(TypeSentence(playerNickname));
    }

    IEnumerator TypeSentence(string playerNickname)
    {
        for (index = 0; index < sentence.Length; index++)
        {
            speech.text = "";
            string currentSentence = sentence[index].Replace("[nickname]", playerNickname);
            for (int i = 0; i < currentSentence.Length; i++)
            {
                speech.text += currentSentence[i];
                yield return new WaitForSeconds(0.05f); // Intervalo de tempo entre cada caractere
            }
            yield return new WaitForSeconds(1.5f); // Intervalo de tempo após a exibição de cada sentença
        }
        Sair.SetActive(true);
        GM.intro = true;

    }

    public void NextSextence(string playerNickname)
    {
        if (index < sentence.Length - 1)
        {
            index++;
            speech.text = "";
            StartCoroutine(TypeSentence(playerNickname));
        }
        else
        {
            speech.text = "";
            // Após o término do diálogo, ativa os objetos desejados
            dialogueObj.SetActive(false);
            HUD.SetActive(true);
            playerController.SetActive(true);
            GameController.SetActive(true);
        }
    }




}
