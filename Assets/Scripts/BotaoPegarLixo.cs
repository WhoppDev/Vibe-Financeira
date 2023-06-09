using UnityEngine;

public class BotaoPegarLixo : MonoBehaviour
{
    private GameObject objetoLixo;

    public void ConfigurarBotao(GameObject lixo)
    {
        objetoLixo = lixo;
    }

    public void OnButtonPegarLixo()
    {
        if (objetoLixo != null)
        {
            Destroy(objetoLixo);
        }
    }
}
