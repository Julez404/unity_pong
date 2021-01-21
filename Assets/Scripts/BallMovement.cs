using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class BallMovement : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip audioEffectMiss, audioEffectHitPlayer, audioEffectHitWall;
    //public AudioClip audioEffectMiss, audioEffectHitPlayer, audioEffectHitWall;

    public float InitialSpeed = 10f;
    int score_player_left = 0;
    int score_player_right = 0;
    public Text scoreDisplayPlayer1;
    public Text scoreDisplayPlayer2;


    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(1, 0) * InitialSpeed;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            float y = hitObject(transform.position, col.transform.position, col.collider.bounds.size.y);
            Vector2 currentDir = GetComponent<Rigidbody2D>().velocity;
            currentDir.y = y * 10;
            GetComponent<Rigidbody2D>().velocity = currentDir;
            audioSource.PlayOneShot(audioEffectHitPlayer, 1f);
        }
        else if (col.gameObject.tag == "Goal")
        {
            audioSource.PlayOneShot(audioEffectMiss, 1f);
            if (GetComponent<Rigidbody2D>().velocity.x < 0)
            {
                print("Goal Player left");
                score_player_left++;
            }
            else
            {
                print("Goal Player right");
                score_player_right++;
            }
            resetBall();
            scoreDisplayPlayer1.text = score_player_left.ToString();
            scoreDisplayPlayer2.text = score_player_right.ToString();
        }
        else
        {
            audioSource.PlayOneShot(audioEffectHitWall, 1f);
        }
    }

    float hitObject(Vector2 ballPos, Vector2 playerPos, float playerSize)
    {
        return (ballPos.y - playerPos.y) / playerSize;
    }

    void resetBall()
    {
        Vector2 temp = new Vector2(0, 0);
        Vector2 currentDir = GetComponent<Rigidbody2D>().velocity;
        System.Random random = new System.Random();
        currentDir.y = Convert.ToSingle(random.NextDouble()) * 10f;
        GetComponent<Rigidbody2D>().velocity = currentDir;
        gameObject.transform.position = temp;
    }
}
