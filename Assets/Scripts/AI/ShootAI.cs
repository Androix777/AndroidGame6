using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Shooter))]
public class ShootAI : MonoBehaviour
{
    GameObject hero;
    private Transform heroTransform;
    [SerializeField] private Shooter shooter;

    private Vector2 vectorToHero;
    public float range;

    void Start()
    {
        hero = GameObject.FindWithTag("Player");
        heroTransform = hero.GetComponent<Transform>();
    }

    void Update()
    {
        if(hero != null)
        {
            vectorToHero = (heroTransform.position - transform.position);
            if (vectorToHero.magnitude <= range)
            {
                shooter.Shoot(vectorToHero.normalized);
            }
        }
    }
}
