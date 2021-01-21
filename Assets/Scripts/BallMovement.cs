using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallMovement : MonoBehaviour
{
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

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            float y = hitObject(transform.position, col.transform.position, col.collider.bounds.size.y);
            Vector2 currentDir = GetComponent<Rigidbody2D>().velocity;
            currentDir.y = y * 10;
            GetComponent<Rigidbody2D>().velocity = currentDir;
        }
        if (col.gameObject.tag == "Goal")
        {
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
    }

    float hitObject(Vector2 ballPos, Vector2 playerPos, float playerSize)
    {
        return (ballPos.y - playerPos.y) / playerSize;
    }

    void resetBall()
    {
        Vector2 temp = new Vector2(0,0);
        gameObject.transform.position = temp;
    }
}
