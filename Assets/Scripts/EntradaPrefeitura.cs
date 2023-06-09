using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EntradaPrefeitura : MonoBehaviour
{
    public string cena;
    private bool canEnterScene = false;
    public GameObject Button;
    public GameObject player;

    private void Awake()
    {
        Button.SetActive(false);
    }

    // Start is called before the first frame update
    void Update()
    {



    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            canEnterScene = true;
            Button.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            canEnterScene = false;
            Button.SetActive(false);
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
