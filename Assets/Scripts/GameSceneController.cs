using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameSceneController : MonoBehaviour
{

    public float enemySpawnInterval = 7.0f;
    private float enemyTimer = 0.0f;
    public GameObject asteroidPrefab;
    public GameObject playerPrefab;
    public int score = 0;
    public int lives = 3;

    public Text scoreText;
    public Image[] liveImages;
    private float respawnTimer = 3.0f;
    private bool bIsDead = false;
    private LevelManager lvlMan;
    public Canvas canvas;
    public GameOver gameOver;
    

    // Use this for initialization
    void Start()
    {
        Respawn();
        score = 0;
        scoreText.text = "Score: " + score.ToString();
        lvlMan = GetComponent<LevelManager>();

    }

    // Update is called once per frame
    void Update()
    {
        enemyTimer -= Time.deltaTime;
        if (enemyTimer <= 0)
        {

            enemyTimer = enemySpawnInterval;
            if (enemySpawnInterval <= 1.5f)
            {
                enemySpawnInterval = -Random.Range(0.01f, 0.1f);
            }

            
            int direction = Random.Range(1, 4);
            Vector3 position = new Vector3(0,0,0);
            if (direction == 1)
            {
                float x = Random.Range(-16.5f, 16.5f);
                position = new Vector2(x, 10);
            }
            else if (direction == 2)
            {
                float x = Random.Range(-16.5f, 16.5f);
                position = new Vector2(x, -10);
            }
            else if (direction == 3)
            {
                float x = Random.Range(-10, 10);
                position = new Vector2(16.5f, x);
            }
            else if (direction == 3)
            {
                float x = Random.Range(-10, 10);
                position = new Vector2(-16.5f, x);
            }

            Quaternion spawnAngle = Random.rotation;

            GameObject asteroid = Instantiate(asteroidPrefab, position, spawnAngle, gameObject.transform);
            asteroid.transform.rotation = Quaternion.Euler(0, 0, Random.Range(0.0f, 360.0f));

        }

        if (bIsDead)
        {
            respawnTimer -= Time.deltaTime;
        }
        if (respawnTimer <= 0)
        {
            Respawn();
            
        }
    }

    public void LifeLoss()
    {
        if (lives == 0)
        {
            GameOver();
        }
        else
        {
            lives--;
            liveImages[lives].enabled = false;
            bIsDead = true;
        }

    }

    void Respawn()
    {

        Camera cam = Camera.main;
        Vector3 spawnPoint = cam.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 10f));

        Instantiate(playerPrefab, spawnPoint, Quaternion.identity, gameObject.transform);
        respawnTimer = 3.0f;
        bIsDead = false;

    }

    public void AddScore(int points)
    {
        score = score + points;
        scoreText.text = "Score: " + score.ToString();
    }

    void GameOver()
    {
        gameOver.GameLost(score);
        canvas.enabled = false;
    }
}
