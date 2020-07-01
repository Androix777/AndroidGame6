using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Move))]
[RequireComponent(typeof(Shooter))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private Shooter shooter;
    [SerializeField] private Move moveComponent;
    [SerializeField] private bool InputMouse;
    void Start()
    {

    }

    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        Debug.Log(movement.ToString());
        moveComponent.SetMove(movement);

        if (!InputMouse)
        {
            if (Input.GetKey("up"))
            {
                shooter.Shoot(0);
            }else
            if (Input.GetKey("down"))
            {
                shooter.Shoot(180);
            }else
            if (Input.GetKey("left"))
            {
                shooter.Shoot(90);
            }else
            if (Input.GetKey("right"))
            {
                shooter.Shoot(270);
            }
        }
        else
        {
            if (Input.GetMouseButton(0))
            {
                RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero,int.MaxValue);
                if (hit)
                {
                    shooter.Shoot(hit.point - (Vector2)transform.position);
                }
            }
        }
        
    }


}
