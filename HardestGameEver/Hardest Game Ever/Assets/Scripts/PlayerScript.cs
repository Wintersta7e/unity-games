using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public float moveSpeed = 1f;

    private const string HORIZONTAL_INPUT = "Horizontal";
    private const string VERTICAL_INPUT = "Vertical";

    private void FixedUpdate()
    {
        Vector2 temp = transform.position;

        if (Input.GetAxis(HORIZONTAL_INPUT) > 0)
        {
            temp.x += moveSpeed * Time.deltaTime;
        }
        else if (Input.GetAxis(HORIZONTAL_INPUT) < 0)
        {
            temp.x -= moveSpeed * Time.deltaTime;
        }
        if (Input.GetAxis(VERTICAL_INPUT) > 0)
        {
            temp.y += moveSpeed * Time.deltaTime;
        }
        else if (Input.GetAxis(VERTICAL_INPUT) < 0)
        {
            temp.y -= moveSpeed * Time.deltaTime;
        }

        transform.position = temp;
    }

    private void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == "Enemy")
        {
            GameManager.instance.PlayerDied();
        }

        if (target.tag == "Goal")
        {
            GameManager.instance.PlayerReachedGoal();
        }
    }

}
