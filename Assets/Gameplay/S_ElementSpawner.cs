using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;


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

    [SerializeField] private float Range = 2;

    [SerializeField] private float StartTime = 5;

    private void Start()
    {
        Invoke("SpawnElement",StartTime);
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
        Vector3 spawnPos = spawnPositions[Random.Range(0,spawnPositions.Count)].position;
        spawnPos += new Vector3(Random.Range(-Range,Range),Random.Range(-Range,Range),0);
        Instantiate(element.objectToSpawn, spawnPos,spawnPositions[0].rotation);
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
                currentSpawn = 0;
                currentWave = waves.Count - 1;
                Invoke("SpawnWave",waves[currentWave].delayBetweenWaves);
            }
         
        }
    }

}
