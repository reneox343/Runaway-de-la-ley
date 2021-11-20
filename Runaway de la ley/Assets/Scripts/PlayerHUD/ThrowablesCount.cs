using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ThrowablesCount : MonoBehaviour
{

    private Throwables throwablescript;
    public TMP_Text throwables;
    void Start()
    {
        throwablescript = GameObject.Find("Player").GetComponent<Throwables>();
    }

    void Update()
    {
        throwables.text = throwablescript.generalAmmo.ToString();
    }
}
