using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectorSkript : MonoBehaviour
{
    public Text scoreText;
    private int score;

    public void IncreaseScore()
    {
        score++;

        scoreText.text = "Score: " + score;
    }

    public void OnTriggerEnter2D(Collider2D target)
    {
        //if our Object is Bomb, collect it ---> saves a lot of memory ;D
        if (target.tag == "Bomb")
        {
            IncreaseScore();
            target.gameObject.SetActive(false);
        }
    }

}
