using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
[RequireComponent(typeof(Shooter))]
public class MobSpawner : MonoBehaviour
{
    public Shooter shooter;
    public GameObject[] mobs;
    public float spawnRate;
    public int waveNumber;
    public int numOfSpawns;

    public ParticleSystem.MinMaxCurve waveFactor;
    [System.NonSerialized] public UnityEvent levelEventEnd = new UnityEvent();
    private bool wavesInProgress = false, allEnemiesDied = true;
    void Start()
    {

    }

    void Update()
    {
        if(!wavesInProgress && !allEnemiesDied && transform.childCount == 0)
        {
            allEnemiesDied = true;
            levelEventEnd.Invoke();
        }
    }

    public void StartWaves()
    {
        wavesInProgress = true;
        allEnemiesDied = false;
        InvokeRepeating("Spawn", 0, spawnRate);
    }

    void Spawn()
    {
        int wave = 0;
        float Factor = 0;
        float waveF = wave;
        float waveNumberF = this.waveNumber;
        switch (waveFactor.mode)
        {
            case ParticleSystemCurveMode.Constant:
                Factor= waveFactor.constant;
                break;
            case ParticleSystemCurveMode.Curve:
                Factor = waveFactor.curve.Evaluate(waveF / waveNumberF);
                break;
            case ParticleSystemCurveMode.TwoConstants:
                Factor = Random.Range(waveFactor.constantMin,waveFactor.constantMax);
                break;
                case ParticleSystemCurveMode.TwoCurves:
                Factor = Random.Range(waveFactor.curveMin.Evaluate(waveF/waveNumberF),waveFactor.curveMax.Evaluate(waveF/waveNumberF));
            break;
        }

        for(int i = 0; i<numOfSpawns + wave * Factor; i++)
        {
            shooter.projectile = mobs[Random.Range(0,mobs.Length)];
            shooter.Shoot(0, true, transform);
        }
        wave++;
        if (wave == waveNumber){
            wavesInProgress = false;
            CancelInvoke();
        }
    }
}
