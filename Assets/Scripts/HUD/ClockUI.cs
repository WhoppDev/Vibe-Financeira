using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockUI : MonoBehaviour
{
    public float dayTime;
    public int dayCount;
    public float timeScale = 1f; // Fator de escala para ajustar a velocidade do tempo

    private ProfissaoManager profissao;

    private void Start()
    {
        profissao = FindObjectOfType<ProfissaoManager>();

        dayCount = 0;
        dayTime = 0;
    }

    private void Update()
    {
        dayTime += Time.deltaTime * timeScale;

        if (dayTime >= 24)
        {
            dayTime = 0;
            dayCount++;
        }

        transform.localEulerAngles = Vector3.forward * ((720 * dayTime) / 24) * -1;

        // Use o switch para controlar diferentes eventos com base no hor�rio do jogo
        switch ((int)dayTime)
        {
            case 8: // Evento �s 8h
                InicioLimpeza();
                break;
            case 10: // Evento �s 8h
                FimLimpeza();
                break;
        }
    }

    private void InicioLimpeza()
    {
        // L�gica para o evento �s 8h
        profissao.IniciarEventoLixo();
    }

    private void FimLimpeza()
    {
        // L�gica para o evento �s 8h
        profissao.EncerrarEventoLixo();
    }
}
