using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClockUI : MonoBehaviour
{
    public float dayTime;
    public int dayCount;
    public float timeScale = 1f; // Fator de escala para ajustar a velocidade do tempo

    public ProfissaoManager profissao;

    private void Start()
    {
        dayCount = 0;
        dayTime = 0;
    }


    private void Update()
    {
        if(profissao == null)
        {
            profissao = FindObjectOfType<ProfissaoManager>();
        }

        dayTime += Time.deltaTime * timeScale;

        if (dayTime >= 24)
        {
            dayTime = 0;
            dayCount++;
        }

        transform.localEulerAngles = Vector3.forward * ((720 * dayTime) / 24) * -1;

        // Use o switch para controlar diferentes eventos com base no horário do jogo
        switch ((int)dayTime)
        {
            case 8: // Evento às 8h
                InicioLimpeza();
                break;
            case 10: // Evento às 8h
                FimLimpeza();
                break;
        }
    }

    private void InicioLimpeza()
    {
        // Lógica para o evento às 8h
        profissao.IniciarEventoLixo();
    }

    private void FimLimpeza()
    {
        // Lógica para o evento às 8h
        profissao.EncerrarEventoLixo();
    }
}
