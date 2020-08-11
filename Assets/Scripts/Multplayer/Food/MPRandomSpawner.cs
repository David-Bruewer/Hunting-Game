using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

//Spawns enemies randomly on Server
public class MPRandomSpawner : NetworkBehaviour
{
    //Transform array of all enemy spawnpoints 
    public Transform[] SpawnPoints;

    //The enemy to be spawned
    public GameObject enemy;

    //Checks if max enemy count spawned
    public bool isSpawned;

    //Check if spawning is allowed
    public bool allowSpawn = true;

    //Random point to be spawned 
    public int randSpawnPoint;

    
    // Update is called once per frame

    void Update()
    {
        //Checks if spawning is allowed, if so then Enemy is spawned every 3 seconds 
        isSpawned = EnemyLoader.isFull;
        if (!isSpawned && allowSpawn )
        {
            StartCoroutine(SpawnTimer());
        }
    }

    //Timer which spawns 1 enmy every 3 seconds 
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

