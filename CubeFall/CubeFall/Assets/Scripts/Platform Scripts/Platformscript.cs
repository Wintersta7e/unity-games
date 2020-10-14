using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platformscript : MonoBehaviour
{
    public float moveSpeed = 2f;
    public float boundY = 6f;

    public bool movingPlatformLeft, movingPlatformRight, isBreakable, isSpike, isPlatform;

    private Animator anim;
    private const string PLAYER = "Player";

    public void Awake()
    {
        if (isBreakable)
            anim = GetComponent<Animator>();
    }


    // Update is called once per frame
    public void Update()
    {
        Move();
    }

    public void Move()
    {
        Vector2 temp = transform.position;
        temp.y += moveSpeed * Time.deltaTime;
        transform.position = temp;

        if (temp.y >= boundY)
        {
            gameObject.SetActive(false);
        }
    }

    public void BreakableDeactivate()
    {
        Invoke("DeactivateGameObject", 0.3f);

    }

    public void DeactivateGameObject()
    {
        SoundManager.instance.IceBreakSound();
        gameObject.SetActive(false);
    }

    /// <summary>
    /// On trigger enter
    /// </summary>
    /// <param name="target"></param>
    public void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == PLAYER)
        {
            if (isSpike)
            {
                target.transform.position = new Vector2(1000f, 1000f);
                SoundManager.instance.GameOverSound();
                GameManager.instance.RestartGame();
            }
        }
    }

    /// <summary>
    /// On collision enter
    /// </summary>
    /// <param name="target"></param>
    public void OnCollisionEnter2D(Collision2D target)
    {
        if (target.gameObject.tag == PLAYER)
        {
            if (isBreakable)
            {
                SoundManager.instance.LandSound();
                anim.Play("Break");
            }
            if (isPlatform)
            {
                SoundManager.instance.LandSound();

            }
        }
    }

    /// <summary>
    /// On collision stay
    /// </summary>
    /// <param name="target"></param>
    public void OnCollisionStay2D(Collision2D target)
    {
        if (target.gameObject.tag == PLAYER)
        {
            if (movingPlatformLeft)
            {
                target.gameObject.GetComponent<PlayerMovement>().CalcVelocity(-1f);
            }
            if (movingPlatformRight)
            {
                target.gameObject.GetComponent<PlayerMovement>().CalcVelocity(1f);
            }
        }
    }
}
