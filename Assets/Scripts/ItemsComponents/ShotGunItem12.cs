using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotGunItem12 : MonoBehaviour
{
    [SerializeField] GameObject enemyDetector;
    [SerializeField] EnemyDetector detector;

    [SerializeField] float numberBullet = 1f;
    [SerializeField] float numberBulletIncrease = 0.2f;

    bool activeEffect = false;

    void Start()
    {
        detector = GetComponentInChildren<EnemyDetector>();
    }

    // Update is called once per frame
    void Update()
    {
        if (detector != null)
        {
            if (detector.numberEnemy > 0 != activeEffect)
            {
                activeEffect = detector.numberEnemy > 0;
                foreach (Shooter shooter in gameObject.GetComponent<Core>().combatShooters)
                {
                    shooter.fireRateValue.AddValue(numberBullet * (activeEffect ? 1:-1)) ;
                    shooter.fireRateValue.AddIncrease(numberBulletIncrease * (activeEffect ? 1 : -1));
                }
            }
        }
        
    }
}
