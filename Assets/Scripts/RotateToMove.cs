using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateToMove : MonoBehaviour
{

    new Rigidbody2D rigidbody;  
    [SerializeField] Transform rotateObj;
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (rigidbody != null)
        {
            float angle = AngleTo(Vector2.zero, rigidbody.velocity);
            rotateObj.rotation = Quaternion.Euler(0,0,angle);
        }
        
    }

    private float AngleTo(Vector2 pos, Vector2 target)
    {
        Vector2 diference = target - pos;
        float sign = (target.y < pos.y) ? -1.0f : 1.0f;
        return Vector2.Angle(Vector2.right, diference) * sign;
    }
}
