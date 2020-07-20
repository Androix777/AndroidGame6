using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpeedUp : MonoBehaviour
{
    private int movePlus = 5;
    void Start()
    {
        gameObject.GetComponent<PlayerController>().moveComponent.speed += movePlus;
    }

    void Update()
    {
        
    }
}
