using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Exit : MonoBehaviour
{

    public void BackToWorldMap()
    {
        SceneManager.LoadScene("MapaCentral");
    }
}
