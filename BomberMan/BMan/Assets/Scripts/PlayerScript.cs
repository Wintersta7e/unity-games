using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public float speed = 10f;
    private float minX = -2.55f;
    private float maxX = 2.55f;

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
    }

    /// <summary>
    /// Logic for moving player-asset around
    /// </summary>
    void MovePlayer()
    {
        float h = Input.GetAxis("Horizontal");
        Vector2 currentPos = transform.position; //Vector 2 cause of 2d world


        if (h > 0)
        {
            //go to the right side
            currentPos.x += speed * Time.deltaTime;

        } 
        else if (h < 0)
        {
            //go to the left side
            currentPos.x -= speed * Time.deltaTime;
        }

        if (currentPos.x < minX)
        {
            currentPos.x = minX;
        }
        if (currentPos.x > maxX)
        {
            currentPos.x = maxX;
        }

        transform.position = currentPos;
    }

    //player is killed by the bomb
    private void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == "Bomb")
        {
            Time.timeScale = 0f;
        }
    }
}
