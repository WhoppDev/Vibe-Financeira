using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HudController : MonoBehaviour
{
    public GameObject profiss�esHUD;
    public GameObject inicialHUD;

    private void Start()
    {
        profiss�esHUD.SetActive(false);
        inicialHUD.SetActive(true);
    }

    public void FecharProfiss�es()
    {
        profiss�esHUD.SetActive(false);
        inicialHUD.SetActive(true);
    }

    public void AbrirProfiss�es()
    {
        profiss�esHUD.SetActive(true);
        inicialHUD.SetActive(false);
    }

}
