using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;
using UnityEngine;

public class ContinuePauseMenu : MonoBehaviour
{
    private Button continueButton;

    // Start is called before the first frame update
    void Start()
    {
        continueButton = gameObject.GetComponent<Button>();
        continueButton.onClick.AddListener(continuePlaying);
    }

    void continuePlaying() {
        PauseMenu.pause = false;
    }
}
