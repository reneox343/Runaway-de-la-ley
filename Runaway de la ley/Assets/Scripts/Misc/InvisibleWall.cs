using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvisibleWall : MonoBehaviour
{
    // Start is called before the first frame update
    public bool makeInvisible;

    private void Awake()
    {
        if (makeInvisible) Destroy(gameObject.GetComponent<SpriteRenderer>());
    }

}
