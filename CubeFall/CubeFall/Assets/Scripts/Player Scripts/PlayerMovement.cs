using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D playerBody;
    private const string MOVE_HORIZONTAL = "Horizontal";

    public float moveSpeed = 2f;
    

    // Start is called before the first frame update
    void Awake()
    {
        playerBody = GetComponent<Rigidbody2D>();
    }

    // FixedUpdate is called for RigidBodies
    void FixedUpdate()
    {
        Move();
    }

    public void Move()
    {
        if (Input.GetAxisRaw(MOVE_HORIZONTAL) > 0f)
        {
            CalcVelocity(moveSpeed);
        }
        if (Input.GetAxisRaw(MOVE_HORIZONTAL) < 0f)
        {
            CalcVelocity(-moveSpeed);
        }
    }

    /// <summary>
    /// Calculate the velocity
    /// </summary>
    /// <param name="speed"></param>
    public void CalcVelocity(float speed)
    {
        playerBody.velocity = new Vector2(speed, playerBody.velocity.y);
    }
}
