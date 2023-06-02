using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EntradaPrefeitura : MonoBehaviour
{
    public string cena;
    // Start is called before the first frame update
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            SceneManager.LoadScene(cena);
        }
    }
}
