using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAI : MonoBehaviour
{
    GameObject hero;
    private Move move;
    private Transform heroTransform;
    private Vector2 vectorToHero;
    public float rangeToStop;

    void Start()
    {
        hero = GameObject.FindWithTag("Player");
        heroTransform = hero.GetComponent<Transform>();
        move = gameObject.GetComponent<Move>();
    }

    // Update is called once per frame
    void Update()
    {
        if (hero != null)
        {
            vectorToHero = (heroTransform.position - transform.position);
            if (vectorToHero.magnitude >= rangeToStop)
            {
                move.SetMove(vectorToHero.normalized);
            }
            else
            {
                move.SetMove(Vector2.zero);
            }
        }
    }
}
