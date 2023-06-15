using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EntretenimentoManager : MonoBehaviour
{
    public Image entretenimentoBar;
    public float valorEntretenimento;

    private float targetFillAmount;
    private float currentFillAmount;

    public float diminuicaoDeEntretenimento = 0.05f;
    // Start is called before the first frame update
    void Start()
    {
        currentFillAmount = entretenimentoBar.fillAmount;
        targetFillAmount = currentFillAmount;

        StartFill();
    }

    // Update is called once per frame
    void Update()
    {


        // Verifica se o preenchimento atual é diferente do preenchimento alvo
        if (currentFillAmount != targetFillAmount)
        {
            // Interpola suavemente o preenchimento atual em direção ao preenchimento alvo
            currentFillAmount = Mathf.Lerp(currentFillAmount, targetFillAmount, diminuicaoDeEntretenimento * Time.deltaTime);

            // Atualiza o "fillAmount" da Image UI
            entretenimentoBar.fillAmount = currentFillAmount;
            valorEntretenimento = currentFillAmount;
        }
    }

    // Chamar o método StartFill() para iniciar o preenchimento da barra.
    public void StartFill()
    {
        // Define o preenchimento alvo como 0
        targetFillAmount = 0f;
    }

    public void FillBar()
    {
        // Define o preenchimento alvo como 1 (barra cheia)
        targetFillAmount = 1f;
        StartCoroutine(QuedaEntretenimento());
    }

    public IEnumerator QuedaEntretenimento()
    {
        diminuicaoDeEntretenimento *= 8;
        Debug.Log("Inicio Corotina");
        yield return new WaitForSeconds(10f);
        diminuicaoDeEntretenimento /= 8;
        Debug.Log("Inicio Queda");
        targetFillAmount = 0f;
    }

}
