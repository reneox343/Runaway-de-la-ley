using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Play : MonoBehaviour
{

    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0)){
            SceneManager.LoadScene(1);
        }
    }
    // Update is called once per frame

}
