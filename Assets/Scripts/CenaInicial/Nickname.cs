using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Nickname : MonoBehaviour
{
    public InputField nicknameInputField;

    public void LoadNextScene()
    {
        string playerNickname = nicknameInputField.text;
        PlayerData.instance.playerNickname = playerNickname;
        SceneManager.LoadScene("MapaCentral");
    }
}
