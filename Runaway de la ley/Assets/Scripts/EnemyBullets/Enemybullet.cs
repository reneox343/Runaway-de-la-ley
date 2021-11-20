using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemybullet : MonoBehaviour
{
    //sets the spped of the bullet
    public float bulletSpeed;
    //sets when the bullet will be destroy if it doesnt hit something
    public float deleteTimer;
    //get player
    GameObject player;
    //direction in witch the bullet will travel
    Vector3 direction;



    void Start()
    {
        player = GameObject.Find("Player");
        //finds the direction in with te arrow must be shoot to hit the player and rotates it towars the cahracter
        direction = player.transform.position - gameObject.transform.position;
        direction = Vector3.Normalize(direction);
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(Vector3.forward * (angle + 180));
        
    }

    // Update is called once per frame
    void Update() {
        deleteTimer -= Time.deltaTime;
        if (deleteTimer <= 0)
        {

            Destroy(gameObject);
        }
        gameObject.transform.position += direction * bulletSpeed * Time.deltaTime;
        //gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.down*falloff * Time.deltaTime, ForceMode2D.Force);
    }




    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "EnemyBullet") return;
        Destroy(gameObject);
    }
    //private void RotateTowardsTarget()
    //{
    //    var offset = 90f;
    //    Vector2 direction = target.position - transform.position;
    //    direction.Normalize();
    //    float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
    //    transform.rotation = Quaternion.Euler(Vector3.forward * (angle + offset));
    //}

    //private void MoveTowardsTarget()
    //{
    //    transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
    //}
}
