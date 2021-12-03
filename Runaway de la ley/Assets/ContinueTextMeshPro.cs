using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class ContinueTextMeshPro : MonoBehaviour
{
    public Button continueButton;

    void Start()
    {
        continueButton.onClick.AddListener(Continue);
    }

    void Continue()
    {
        PlayerData data = SaveSystemDataPlayer.loadPlayerData();
        SceneManager.LoadScene(data.level);
    }
}
