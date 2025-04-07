using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //how to define a variable
    //1. access modifier: public or private
    //2. data type: int, float, bool, string
    //3. variable name: camelCase
    //4. value: optional

    private int lives = 3;

    private float playerSpeed;
    private float horizontalInput;
    private float verticalInput;

    public GameManager gm;

    private float horizontalScreenLimit = 9.5f;
    private float verticalScreenLimit = 3.5f; // Added a variable for vertical bounds

    public GameObject bulletPrefab;

    void Start()
    {
        playerSpeed = 6f;
        //This function is called at the start of the game

    }

    void Update()
    {
        //This function is called every frame; 60 frames/second
        Movement();
        Shooting();

    }

    void Shooting()
    {
        //if the player presses the SPACE key, create a projectile
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(bulletPrefab, transform.position + new Vector3(0, 1, 0), Quaternion.identity);
        }
    }

    void Movement()
    {
        //Read the input from the player
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        //Clamp vertical movement to prevent going out of bounds
        float newY = Mathf.Clamp(transform.position.y + (verticalInput * playerSpeed * Time.deltaTime), -verticalScreenLimit, 0);

        //Move the player
        transform.Translate(new Vector3(horizontalInput, 0, 0) * Time.deltaTime * playerSpeed);
        transform.position = new Vector3(transform.position.x, newY, 0);

        //Player leaves the screen horizontally
        if (transform.position.x > horizontalScreenLimit || transform.position.x <= -horizontalScreenLimit)
        {
            transform.position = new Vector3(transform.position.x * -1, transform.position.y, 0);
        }
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Enemy"))
        {
            lives--;
            gm.ChangeLivesText(lives);
            Destroy(collider.gameObject);
            if (lives <= 0)
            {
                Destroy(gameObject);
            }

        }
        else if (collider.CompareTag("Coin"))
        {
            gm.AddScore(5);
            Destroy(collider.gameObject);
        }
    }
}