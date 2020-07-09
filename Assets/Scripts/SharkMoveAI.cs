using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SharkMoveAI : MonoBehaviour
{
    GameObject hero;
    private Move move;
    private Transform heroTransform;
    private Vector2 vectorMove;  
    [Range(-90,90)] public float angleToHero;
    public float rangeToStop;    void Start()
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
            float angle = AngleTo(transform.position , heroTransform.position);
            transform.rotation = Quaternion.Euler(0,0,angle + angleToHero);
            move.SetMove(transform.up);
        }
    }

    private float AngleTo(Vector2 pos, Vector2 target)
    {
        Vector2 diference = target - pos;
        float sign = (target.y < pos.y) ? -1.0f : 1.0f;
        return Vector2.Angle(Vector2.right, diference) * sign;
    }
}
