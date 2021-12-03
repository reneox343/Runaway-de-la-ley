using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletHitbox : MonoBehaviour
{
    public float bulletEnemyDamage;
    public bool destroyOnColision;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player") {

            if (destroyOnColision) {
                Destroy(gameObject);
            }
            

        }
    }

}
