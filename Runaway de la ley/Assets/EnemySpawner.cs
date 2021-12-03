using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    public GameObject enemy;
    public float delayToSpawn;
    public float spawnRate;
    [Range(0, 2)]
    public float yAxisVariatonDown;
    [Range(0,-2)]
    public float yAxisVariatonUp;
    public bool spawnOnPlayerYPosition;
    //palyer
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        InvokeRepeating("spawnEnemy", delayToSpawn, spawnRate);
    }

    void spawnEnemy() {
        Vector3 spawnpositon;
        if (spawnOnPlayerYPosition)
        {
            spawnpositon = new Vector3(gameObject.transform.position.x, player.transform.position.y, 0);

        }
        else 
        {
            spawnpositon = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + Random.Range(yAxisVariatonDown, yAxisVariatonUp), 0);

        }
        Instantiate(enemy, spawnpositon, Quaternion.identity);
    }


}
