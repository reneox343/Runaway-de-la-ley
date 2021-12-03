using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class StoreButton : MonoBehaviour
{
    public Button storeButton;
    // Start is called before the first frame update
    void Start()
    {
        storeButton.onClick.AddListener(loadStore);
    }

    void loadStore() {

        SceneManager.LoadScene(8);
    }
}
