using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class BotaoPegarLixo : MonoBehaviour
{
    [System.Serializable]
    public class LixoEvent : UnityEvent<GameObject> { }

    public LixoEvent onPegarLixo;
    public Button botao1;

    public void OnButtonPegarLixo(GameObject lixo)
    {
        if (lixo != null)
        {
            // Fa�a o que for necess�rio com o objeto de lixo recebido
            Debug.Log("Lixo recebido: " + lixo.name);
            onPegarLixo.Invoke(lixo);
        }
    }
}