using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowablesBox : MonoBehaviour
{
    // Start is called before the first frame update
    [HideInInspector]
    public int throwabletype;
    void Start()
    {
        throwabletype = 1;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player")
        {

            Destroy(gameObject);

        }
    }
}
