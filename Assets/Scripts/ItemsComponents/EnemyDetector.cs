using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDetector : MonoBehaviour
{
    public int numberEnemy = 0;

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        numberEnemy++;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        numberEnemy--;
    }
}
