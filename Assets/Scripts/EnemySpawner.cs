using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    public GameObject enemyPrefab;
    public float spawnRate = 30f;
    public float spawnRateIncrement = 1f;
    public float xLimit = 7f;
    public float lifeTime = 2f;

    private float nextSpawn = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if(Time.time > nextSpawn)
        {
            nextSpawn = Time.time + 60 / spawnRate;

            spawnRate += spawnRateIncrement;

            float rand = Random.Range(-xLimit, xLimit);

            Vector2 spawnPosition = new Vector2(rand,8f);

            GameObject meteor = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);

            Destroy(meteor, lifeTime);
        }

    }
}
