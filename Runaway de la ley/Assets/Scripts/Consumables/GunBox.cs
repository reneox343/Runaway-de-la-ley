using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunBox : MonoBehaviour
{
    // Start is called before the first frame update
    [HideInInspector]
    public int guntype;
    void Start()
    {
        guntype = Random.Range(2, 4);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player") {

            Destroy(gameObject);

        }
    }
}
