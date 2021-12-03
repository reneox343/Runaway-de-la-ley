using System.Collections;
using System.Collections.Generic;
using UnityEngine.Experimental.Rendering.Universal;
using UnityEngine;

public class shineLight : MonoBehaviour
{

    private Light2D light2D;
    public float speed;
    public float outerCircleMin;
    public float outerCircleMax;
    private bool add;
    private bool visible;

    // Start is called before the first frame update
    void Start()
    {
        visible = false;
        light2D = gameObject.GetComponent<Light2D>();
        gameObject.AddComponent<SpriteRenderer>();
        light2D.pointLightOuterRadius = outerCircleMin;
    }

    // Update is called once per frame
    void Update()
    {
        if (visible) changeouterRadius();
    }
    void changeouterRadius() {
        if (light2D.pointLightOuterRadius >= outerCircleMax)
        {
            add = false;
        }
        if (light2D.pointLightOuterRadius <= outerCircleMin)
        {
            add = true;
        }

        if (add)
        {
            light2D.pointLightOuterRadius += Time.deltaTime * speed;
        }
        else
        {
            light2D.pointLightOuterRadius -= Time.deltaTime * speed;
        }

    }

    private void OnBecameVisible()
    {
        visible = true;
    }    
    private void OnBecameInvisible()
    {
        visible = false;
    }
}
