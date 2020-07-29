using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawner : MonoBehaviour
{
    public Transform[] SpawnPoints;
    public GameObject enemy;

    public bool isSpawned;

    public bool allowSpawn = true;

    // Update is called once per frame
    void Update()
    {
        isSpawned = EnemyLoader.isFull;
        if (!isSpawned && allowSpawn )
        {
            StartCoroutine(SpawnTimer());
        }
    }

    IEnumerator SpawnTimer() 
    {
         int randSpawnPoint = Random.Range(0,SpawnPoints.Length);

            Instantiate(enemy,SpawnPoints[randSpawnPoint].position,transform.rotation);

            EnemyLoader.addEnemy();

            allowSpawn = false; 
            yield return new WaitForSeconds(3f); 
            allowSpawn = true;
    }
}
