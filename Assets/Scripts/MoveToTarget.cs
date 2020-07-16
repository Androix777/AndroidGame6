using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToTarget : MonoBehaviour
{
    [SerializeField] GameObject target;
    private Move move;
    private Transform targetTransform;
    private Vector2 vectorToHero;
    public float rangeToStop;

    void Start()
    {
        targetTransform = target.GetComponent<Transform>();
        move = gameObject.GetComponent<Move>();
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {
            vectorToHero = (targetTransform.position - transform.position);
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
