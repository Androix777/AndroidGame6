using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Shooter))]
public class MobSpawner : MonoBehaviour
{
    public Shooter shooter;
    public GameObject[] mobs;
    public float spawnRate;
    public int waveNumber;
    public int numOfSpawns;

    public ParticleSystem.MinMaxCurve waveFactor;
    [SerializeField] int wave;
    void Start()
    {
        wave = 0;
        InvokeRepeating("Spawn", 0, spawnRate);       
    }

    void Update()
    {
        
    }

    void Spawn()
    {
        
        float Factor = 0;
        float waveF = this.wave;
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
            shooter.Shoot(0, true);
        }
        if (wave == waveNumber){
            CancelInvoke();
        }
        wave++;
    }
}
