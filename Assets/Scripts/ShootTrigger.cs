using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootTrigger : MonoBehaviour, ITrigger
{
    [SerializeField] private Shooter shooter;

    void Start()
    {

    }

    void Update()
    {
        
    }

    public void ActivateEffect()
    {
        shooter.Shoot(transform.TransformPoint(Vector2.up) - transform.position, true);
    }
}
