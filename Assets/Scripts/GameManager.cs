using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cinemachine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public CinemachineVirtualCamera virtualCamera;
    public GameObject player;

    public HUDManager hudManager;

    public int dinheiro;

    public ProfissaoManager profissoes;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Impede que o objeto GameManager seja destruído ao carregar uma nova cena
        }
        else
        {
            Destroy(gameObject);
        }

        player = GameObject.FindGameObjectWithTag("Player");

        virtualCamera.Follow = player.transform;
    }

    private void Start()
    {

        hudManager = FindObjectOfType<HUDManager>();
    }

    private void Update()
    {
        hudManager.moneyText.text = dinheiro.ToString();


    }


}
