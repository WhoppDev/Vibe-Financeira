using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialog : MonoBehaviour
{
    public Sprite profile;
    public string[] speechTxt;

    private DialogControl DC;
    private PlayerData playerData;

    private void Start()
    {
        DC = FindObjectOfType<DialogControl>();
        playerData = FindObjectOfType<PlayerData>();
    }

    public void ShowDialog()
    {
        string playerNickname = playerData.playerNickname;
        DC.Speech(playerNickname);
    }
}
