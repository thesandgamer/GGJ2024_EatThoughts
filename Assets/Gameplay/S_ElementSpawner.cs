using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct Spawn
{
    public GameObject objectToSpawn;
    public float timeToSpawnNext;

}

[Serializable]
public struct Wave
{
    public List<Spawn> spawns;
    public float delayBetweenWaves;
}

public class S_ElementSpawner : MonoBehaviour
{
    [SerializeField] private List<Transform> spawnPositions = new List<Transform>();
    [SerializeField] private List<Wave> waves = new List<Wave>();

    private int currentWave = 0;
    private int currentSpawn = 0;

    private void Start()
    {
        SpawnElement();
        //Instantiate(waves[currentWave].spawns[currentSpawn].objectToSpawn, spawnPositions[0].position,spawnPositions[0].rotation);

    }

    public void StartSpawner()
    {
        foreach (var spawn in waves[currentWave].spawns)
        {
            
        }

    }

    public void SpawnWave()
    {
        SpawnElement();
    }

    public void SpawnElement()
    {
        Spawn element = waves[currentWave].spawns[currentSpawn];
        Instantiate(element.objectToSpawn, spawnPositions[0].position,spawnPositions[0].rotation);
        currentSpawn++;
        if (currentSpawn < waves[currentWave].spawns.Count) //Si on à pas ateins la fin des elements à spawn
        {
            Invoke("SpawnElement",element.timeToSpawnNext);
        }
        else //Si on à attein la fin de la vague
        {
            currentWave++;
            if (currentWave < waves.Count)
            {
                currentSpawn = 0;
                Invoke("SpawnWave",waves[currentWave-1].delayBetweenWaves);
            }
            else
            {
                print("At end of spawner");
            }
         
        }
    }

}
