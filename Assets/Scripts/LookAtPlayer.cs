using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtPlayer : MonoBehaviour
{
    GameObject hero;
    private Transform heroTransform;
    private Vector2 vectorToHero;
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
            gameObject.transform.rotation = Quaternion.Euler(0,0,Vector2.SignedAngle(Vector2.up, vectorToHero));
        }
    }
}
