using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    private Rigidbody2D rb2d;
    public float speed;

    void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }
    void Start()
    {

    }

    void Update()
    {
        
    }

    public void SetMove(Vector2 vector)
    {
        rb2d.velocity = vector.normalized * speed;
    }
}
