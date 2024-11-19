using System;
using System.Diagnostics;
using UnityEngine;

public class BirdScript : MonoBehaviour
{
    public Rigidbody2D myRigidBody;
    public int flapStrength = 7;
    public LogicScript logic;
    public bool isAlive = true;
    public bool isRunning = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isAlive && isRunning)
        {
            myRigidBody.linearVelocity = Vector2.up * flapStrength;
        } else if (Input.GetKeyDown(KeyCode.Space) && !isRunning)
        {
            isRunning = true;
            isAlive = true;
            logic.startGame();
        }

        Vector3 screenPos = Camera.main.WorldToScreenPoint(this.transform.position);

        if (screenPos.x < 0 || screenPos.y < 0 ||
            screenPos.x > Screen.width || screenPos.y > Screen.height)
        {
            finishGame();
        }
    }

    private void finishGame()
    {
        logic.gameOver();
        isAlive = false;
        Time.timeScale = 0; // Freeze the game
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        finishGame();
    }
}
