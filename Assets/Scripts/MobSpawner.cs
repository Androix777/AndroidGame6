using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobSpawner : MonoBehaviour
{
    public Shooter shooter;
    public GameObject[] mobs;
    public float spawnRate;
    void Start()
    {
        InvokeRepeating("Spawn", spawnRate, spawnRate);
    }

    void Update()
    {
        
    }

    void Spawn()
    {
        shooter.projectile = mobs[Random.Range(0,mobs.Length)];
        shooter.Shoot(Random.Range(0.0f, 360.0f), true);
    }
}
