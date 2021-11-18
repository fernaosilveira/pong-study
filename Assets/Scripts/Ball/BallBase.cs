using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBase : MonoBehaviour
{
    public Vector3 speed = new Vector3(1, 1);
    private int speedMultiply_b = 1000;
    private Vector3 startSpeed;
    public string tagToCheck = "Player";
    

    [Header("Randomization")]
    public Vector2 randSpeedX = new Vector2(1, 3);
    public Vector2 randSpeedY = new Vector2(1, 3);
  
    private Vector3 startPosition;
    private bool canMove = false;


    void Awake()
    {
        startPosition = transform.position;
        startSpeed = speed;
    }
    void Update()
    {
        if (!canMove)
        {
            return;
        }

        StartMovement();
    }

    private void StartMovement()
    {
        transform.Translate(speed * speedMultiply_b * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            OnPlayerCollision();
        }
        
        else
        {
            speed.y *= -1;
        }
    }

    private void OnPlayerCollision()
    {
        speed.x *= -1;

        float rand = Random.Range(randSpeedX.x, randSpeedX.y);
        if (speed.x < 0)
        {
            rand = -rand;
        }
      
        speed.x = rand;

        rand = Random.Range(randSpeedY.x, randSpeedY.y);
        speed.y = rand;
    }

    public void ResetBall()
    {
        transform.position = startPosition;
        speed = startSpeed;
    }

    public void CanMove(bool state)
    {
        canMove = state;
       
    }
}
