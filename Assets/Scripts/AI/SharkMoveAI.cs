using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SharkMoveAI : MonoBehaviour
{

    private Move move;
    private Transform targetTransform;
    private Vector2 vectorMove;  
    [Range(-90,90)] public float angleToTarget;
    public float rangeToStop;    
    
    [SerializeField] bool heroTarget;

    [SerializeField] GameObject target;
    void Start()
    {
        move = gameObject.GetComponent<Move>();
        if (heroTarget)
        {
            target = GameObject.FindWithTag("Player");
            targetTransform = target.GetComponent<Transform>();
        }
        if (target != null)
        {
            targetTransform = target.GetComponent<Transform>();
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {
            float angle = AngleTo(transform.position , targetTransform.position);
            transform.rotation = Quaternion.Euler(0,0,angle + angleToTarget);
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
