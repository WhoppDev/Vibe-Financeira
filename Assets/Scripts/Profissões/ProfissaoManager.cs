using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProfissaoManager : MonoBehaviour
{
    public GameObject EventoLixo;


    public GameManager GM;


    private void Start()
    {
        GM = FindObjectOfType<GameManager>();

        EventoLixo.SetActive(false);
        GM.lixoBtn.SetActive(false);
    }

#region Coletor
    public void IniciarEventoLixo()
    {
        EventoLixo.SetActive(true);
        ActivateAllChildren(EventoLixo.transform);
    }

    public void EncerrarEventoLixo()
    {
        EventoLixo.SetActive(false);
        DeactivateAllChildren(EventoLixo.transform);
    }

    private void ActivateAllChildren(Transform parent)
    {
        foreach (Transform child in parent)
        {
            child.gameObject.SetActive(true);
            ActivateAllChildren(child);
        }
    }

    private void DeactivateAllChildren(Transform parent)
    {
        foreach (Transform child in parent)
        {
            child.gameObject.SetActive(false);
            DeactivateAllChildren(child);
        }
    }
#endregion

}