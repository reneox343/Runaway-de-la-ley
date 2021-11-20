using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AnimationTextMeshPro : MonoBehaviour
{
    // Start is called before the first frame update
    public TMP_Text astiModeText;
    public float timer;
    private float gloabalTimer;
    private Gun gunscript;

    private int currentColor = 0;
    void Start()
    {
        gloabalTimer = timer;
        gunscript = GameObject.Find("Player").GetComponent<Gun>();
    }

    // Update is called once per frame
    void Update()
    {
        astiModeAnimation();
    }


    void astiModeAnimation() {
        if (gunscript.astiMode)
        {
            astiModeText.enabled = true;
            gloabalTimer -= Time.deltaTime;
            if (gloabalTimer <= 0)
            {
                currentColor += 10;
                if (currentColor + 20 > 255)
                {
                    currentColor = 0;
                }
                Color32 topColor = new Color32((byte)(currentColor + 50), 0, 0, 255);
                Color32 bottomColor = new Color32((byte)currentColor, 0, 0, 255);
                astiModeText.colorGradient = new VertexGradient(topColor, topColor, bottomColor, bottomColor);
                gloabalTimer = timer;
            }
        }
        else {
            astiModeText.enabled = false;
        }

    }
}
