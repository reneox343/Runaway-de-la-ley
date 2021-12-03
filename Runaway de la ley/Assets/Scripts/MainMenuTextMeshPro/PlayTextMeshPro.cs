using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayTextMeshPro : MonoBehaviour
{

    public Button newGameButton;

    void Start()
    {
        newGameButton.onClick.AddListener(newGame);
    }

    void newGame()
    {
        SaveSystemDataPlayer.savePlayerData(3,0,new bool[4]{ false, false, false,false }, new bool[4] { false, false, false, false }, new bool[4] { false, false, false, false }, new bool[4] { false, false, false, false });
        SceneManager.LoadScene(3);
    }

}