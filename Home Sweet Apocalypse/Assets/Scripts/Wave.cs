using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class Wave : MonoBehaviour
{

    public List<GameObject> spawnLocations = new List<GameObject>();
    public GameObject normalZombiePrefab;
    public GameObject speedZombiePrefab;
    public GameObject bruteZombiePrefab;


    private int wave;
    private int zombiesToSpawn;
    private float spawnInterval;
    private float lastSpawnTime;
    private int zombiesRemaining;
    private int zombiesSpawned;
    private float lastZombieDiedTime;

    private System.Random rng = new System.Random();


    void Start()
    {
        wave = 1;
        zombiesToSpawn = 10;
        spawnInterval = 2f;
        lastSpawnTime = Time.time;
        lastZombieDiedTime = Time.time;
        zombiesRemaining = zombiesToSpawn;
        zombiesSpawned = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(zombiesRemaining);

        if(Time.time - lastSpawnTime > spawnInterval && zombiesRemaining > 0 && zombiesSpawned < zombiesToSpawn) // spawn zombies
        {
            lastSpawnTime = Time.time;
            Shuffle(spawnLocations);
            int max = Math.Min(zombiesRemaining, spawnLocations.Count);
            int locationsToPick = rng.Next(max) + 1;

            for(int i = 0; i < locationsToPick; i++)
            {
                zombiesSpawned++;
                GameObject zombie;
                if(wave == 1)
                {
                    zombie = Instantiate(normalZombiePrefab);
                    zombie.transform.position = spawnLocations[i].transform.position;
                    zombie.transform.rotation = spawnLocations[i].transform.rotation;
                    continue;
                }

                int rnd = rng.Next(100);
                if(rnd <= 50)
                {
                    zombie = Instantiate(normalZombiePrefab);
                }
                else if(rnd <= 75)
                {
                    zombie = Instantiate(speedZombiePrefab);
                }
                else
                {
                    zombie = Instantiate(bruteZombiePrefab);
                }

                if(zombie != null)
                {
                    zombie.transform.position = spawnLocations[i].transform.position;
                    zombie.transform.rotation = spawnLocations[i].transform.rotation;
                }
            }
        }
    }


    private void Shuffle(List<GameObject> list)
    {
        int n = list.Count;
        while (n > 1)
        {
            n--;
            int k = rng.Next(n + 1);
            GameObject value = list[k];
            list[k] = list[n];
            list[n] = value;
        }
    }

    private void startNextWave()
    {
        wave++;
        zombiesToSpawn += 3;
        zombiesRemaining = zombiesToSpawn;
        spawnInterval *= 0.9f;
        zombiesSpawned = 0;
    }

    public void zombieDied()
    {
        if (Time.time < lastZombieDiedTime + 0.01f) return;
        lastZombieDiedTime = Time.time;
        zombiesRemaining--;
        Debug.Log("zombie died");
        if(zombiesRemaining == 0 )
        {
            startNextWave();
        }
    }
}
