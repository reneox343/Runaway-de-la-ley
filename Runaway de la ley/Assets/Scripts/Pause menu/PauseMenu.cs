using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    [HideInInspector]
    public static bool pause;
    private Canvas playerHUD;
    private Canvas pauseMenu;
    // Start is called before the first frame update
    void Start()
    {
        pause = false;
        playerHUD = GameObject.Find("PlayerHUD").GetComponent<Canvas>();
        pauseMenu = GameObject.Find("PauseMenu").GetComponent<Canvas>();
        pauseMenu.enabled = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            switch (pause) {
                case true:
                    pause = false;
                    break;
                case false:
                    pause = true;
                    break;
            }
        }
        switch (pause)
        {
            case true:
                Time.timeScale = 0;
                pauseMenu.enabled = true;
                break;
            case false:
                Time.timeScale = 1;
                pauseMenu.enabled = false;
                break;

        }
    }
}
