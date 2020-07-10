using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMoveAI : MonoBehaviour
{
    
    private Move move;
    private Vector2 vectorToMove;
    public float distToCenter;
    private float timeMove;
    private Vector3 randomPosition;
    void Start()
    {
        move = gameObject.GetComponent<Move>();
        GenerationVectorToMove();
    }

    // Update is called once per frame
    void Update()
    {

        if (Vector2.Distance(randomPosition,transform.position) < 1f)
        {
            GenerationVectorToMove();     
        }
        vectorToMove = (randomPosition - transform.position);
        move.SetMove(vectorToMove.normalized);
    }

    void GenerationVectorToMove()
    {
        randomPosition = (Vector3.up * Random.Range(-1f,1f) + (Vector3.right * Random.Range(-1f,1f))).normalized * Random.Range(0,distToCenter);
    }
}
