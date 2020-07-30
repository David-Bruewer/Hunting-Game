using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class MPRandomSpawner : NetworkBehaviour
{
    public Transform[] SpawnPoints;
    public GameObject enemy;

    public bool isSpawned;

    public bool allowSpawn = true;


    public int randSpawnPoint;

    
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
        
        randSpawnPoint = Random.Range(0,SpawnPoints.Length);

        GameObject mole = Instantiate(enemy,SpawnPoints[randSpawnPoint].position,transform.rotation);
        NetworkServer.Spawn(mole);


        EnemyLoader.addEnemy();

        allowSpawn = false; 
        yield return new WaitForSeconds(3f); 
        allowSpawn = true;
    }
}

