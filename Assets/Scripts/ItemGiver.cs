using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ItemGiver : MonoBehaviour
{
    public string componentName;
    void Start()
    {
        
    }

    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            col.gameObject.AddComponent(Type.GetType(componentName));
            Destroy(gameObject);
        }
    }
}
