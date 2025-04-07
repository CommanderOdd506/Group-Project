using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public GameObject enemyOnePrefab;
    public GameObject enemyTwoPrefab;
    public GameObject coinPrefab;
    public GameObject cloudPrefab;

    public float horizontalScreenSize;
    public float verticalScreenSize;

    public TextMeshProUGUI livesText;
    public TextMeshProUGUI scoreText;

    private int score;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("CreateEnemyOne", 1, 2);
        if (enemyTwoPrefab != null)
        {
            InvokeRepeating("CreateEnemyTwo", 5, 6);
        }
        InvokeRepeating("CreateCoin", 2, 6);
        CreateSky();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void CreateSky()
    {
        for (int i = 0; i < 30; i++)
        {
            Instantiate(cloudPrefab, new Vector3(Random.Range(-horizontalScreenSize, horizontalScreenSize), Random.Range(-verticalScreenSize, verticalScreenSize), 0), Quaternion.identity);
        }

    }

    void CreateCoin()
    {
        Instantiate(coinPrefab, new Vector3(10, Random.Range(-3f, 0f), 0), Quaternion.identity);
    }

    void CreateEnemyOne()
    {
        Instantiate(enemyOnePrefab, new Vector3(Random.Range(-9f, 9f), 6.5f, 0), Quaternion.identity);
    }

    void CreateEnemyTwo()
    {
        Instantiate(enemyTwoPrefab, new Vector3(Random.Range(-9f, 9f), 6.5f, 0), Quaternion.identity);
    }
    public void AddScore(int earnedScore)
    {
        score = score + earnedScore;
        scoreText.text = "Score: " + score;
    }

    public void ChangeLivesText(int currentLives)
    {
        livesText.text = "Lives: " + currentLives;
    }
}
