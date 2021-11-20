using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class TutorialTextMeshPro : MonoBehaviour
{

    public Button tutorial;

	void Start()
	{
		Button btn = tutorial.GetComponent<Button>();
		btn.onClick.AddListener(playTutorial);
	}
    void playTutorial() {

        SceneManager.LoadScene(1);

    }
}
