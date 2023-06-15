using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CelularHud : MonoBehaviour
{
    public GameObject hudGeral;
    public GameObject hudCelular;
    public GameObject playerController;

    private Vector2 startPos;
    private Vector2 currentPos;

    private bool canDetectSwipe = true;



    // Start is called before the first frame update
    void Start()
    {
        hudGeral.SetActive(true);
        playerController.SetActive(true);
        hudCelular.SetActive(false);
        
    }

    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                startPos = touch.position;
                canDetectSwipe = true; // Habilita a detecção de swipe
            }

            if (touch.phase == TouchPhase.Moved && canDetectSwipe)
            {
                currentPos = touch.position;

                float swipeDistance = (currentPos - startPos).magnitude;

                if (swipeDistance > 100f)
                {
                    FecharCelular();
                    canDetectSwipe = false; // Desabilita a detecção de swipe após o primeiro swipe
                }
            }

            if (touch.phase == TouchPhase.Ended)
            {
                canDetectSwipe = true; // Permite a detecção de swipe novamente no próximo toque
            }
        }
    }


    public void AbrirCelular()
    {
        hudGeral.SetActive(false);
        playerController.SetActive(false);
        hudCelular.SetActive(true);
    }

    public void FecharCelular()
    {
        hudGeral.SetActive(true);
        playerController.SetActive(true);
        hudCelular.SetActive(false);
    }


}
