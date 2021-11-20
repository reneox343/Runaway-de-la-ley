using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ExitTextMeshPro : MonoBehaviour
{
	public Button Exit;

	void Start()
	{
		Button btn = Exit.GetComponent<Button>();
		btn.onClick.AddListener(exit);
	}

	void exit()
	{
		Application.Quit();
	}


}
