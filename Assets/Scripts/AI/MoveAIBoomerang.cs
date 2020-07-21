using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAIBoomerang : MonoBehaviour
{
    [SerializeField] new  Rigidbody2D rigidbody;
    [SerializeField] float time;
    private bool active = true;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime;
        if (time <=0 && active) 
        {
            active = false;
            rigidbody.velocity = -rigidbody.velocity;
        }
    }
}
