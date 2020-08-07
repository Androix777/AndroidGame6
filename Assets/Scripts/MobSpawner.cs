using UnityEngine;
using UnityEngine.Events;
using System;
[RequireComponent(typeof(Shooter))]
public class MobSpawner : MonoBehaviour
{
    public Shooter shooter;
    public GameObject[] mobs;
    public float spawnRate;
    private float spawnRateCurrent;
    public int waveNumber;
    private int waveNumberCurrent;
    public int numOfSpawns;
    private int numOfSpawnsCurrent;

    public ParticleSystem.MinMaxCurve waveFactor;
    [System.NonSerialized] public UnityEvent battleEnd = new UnityEvent();
    private bool wavesInProgress = false, allEnemiesDied = true;
    void Start()
    {
        ResetToDefault();
    }

    void Update()
    {
        if(!wavesInProgress && !allEnemiesDied && transform.childCount == 0)
        {
            allEnemiesDied = true;
            battleEnd.Invoke();
        }
    }

    public void StartWaves(bool setDefault = true)
    {
        if(setDefault)
        {
            ResetToDefault();
        }
        wavesInProgress = true;
        allEnemiesDied = false;
        InvokeRepeating("Spawn", 0, spawnRateCurrent);
    }

    public void StartWaves(BattleVariant battleVariant)
    {
        spawnRateCurrent = spawnRate * battleVariant.spawnRateMult + battleVariant.spawnRatePlus;
        waveNumberCurrent = (int)Math.Round(waveNumber * battleVariant.waveNumberMult) + battleVariant.waveNumberPlus;
        numOfSpawnsCurrent = (int)Math.Round(numOfSpawns * battleVariant.numOfSpawnsMult) + battleVariant.numOfSpawnsPlus;
        StartWaves(false);
    }

    void Spawn()
    {
        int wave = 0;
        float Factor = 0;
        float waveF = wave;
        float waveNumberF = this.waveNumberCurrent;
        switch (waveFactor.mode)
        {
            case ParticleSystemCurveMode.Constant:
                Factor= waveFactor.constant;
                break;
            case ParticleSystemCurveMode.Curve:
                Factor = waveFactor.curve.Evaluate(waveF / waveNumberF);
                break;
            case ParticleSystemCurveMode.TwoConstants:
                Factor = UnityEngine.Random.Range(waveFactor.constantMin,waveFactor.constantMax);
                break;
                case ParticleSystemCurveMode.TwoCurves:
                Factor = UnityEngine.Random.Range(waveFactor.curveMin.Evaluate(waveF/waveNumberF),waveFactor.curveMax.Evaluate(waveF/waveNumberF));
            break;
        }

        for(int i = 0; i<numOfSpawnsCurrent + wave * Factor; i++)
        {
            shooter.projectile = mobs[UnityEngine.Random.Range(0,mobs.Length)];
            shooter.Shoot(0, true, transform);
        }
        wave++;
        if (wave == waveNumberCurrent){
            wavesInProgress = false;
            CancelInvoke();
        }
    }

    public void ResetToDefault()
    {
        spawnRateCurrent = spawnRate;
        waveNumberCurrent = waveNumber;
        numOfSpawnsCurrent = numOfSpawns;
    }
}
