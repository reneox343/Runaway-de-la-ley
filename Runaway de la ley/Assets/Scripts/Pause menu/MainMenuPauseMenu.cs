using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MainMenuPauseMenu : MonoBehaviour
{
    private Button mainMenu;

    // Start is called before the first frame update
    void Start()
    {
        mainMenu = gameObject.GetComponent<Button>();
        mainMenu.onClick.AddListener(loadMainMenu);
    }

    void loadMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
