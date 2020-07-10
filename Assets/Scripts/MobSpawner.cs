using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobSpawner : MonoBehaviour
{
    public Shooter shooter;
    public GameObject[] mobs;
    public float spawnRate;
    public int numOfSpawns;
    void Start()
    {
        InvokeRepeating("Spawn", spawnRate, spawnRate);
    }

    void Update()
    {
        
    }

    void Spawn()
    {
        for(int i = 0; i<numOfSpawns; i++)
        {
            shooter.projectile = mobs[Random.Range(0,mobs.Length)];
            shooter.Shoot(0, true);
        }
    }
}
