using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HudController : MonoBehaviour
{
    public GameObject profissõesHUD;
    public GameObject inicialHUD;

    private void Start()
    {
        profissõesHUD.SetActive(false);
        inicialHUD.SetActive(true);
    }

    public void FecharProfissões()
    {
        profissõesHUD.SetActive(false);
        inicialHUD.SetActive(true);
    }

    public void AbrirProfissões()
    {
        profissõesHUD.SetActive(true);
        inicialHUD.SetActive(false);
    }

}
