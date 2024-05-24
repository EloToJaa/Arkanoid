using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public List<GameObject> bricks = new List<GameObject>();
    public ArcanoidBall ball;
    public int lives = 3;

    public BrickGenerator brickGenerator;
    public int maxLevel => brickGenerator.levels.Count;
    private int currentLevel = 1;

    public bool gameRunning = false;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    private void Update()
    {
        if(gameRunning)
        {
            if (bricks.Count == 0 && currentLevel == maxLevel)
            {
                EndGame(true);
            }
            if(bricks.Count == 0 && currentLevel < maxLevel)
            {
                currentLevel++;
                ball.StopBall();
                brickGenerator.StartLevel(currentLevel);
            }

            if (lives <= 0)
            {
                EndGame(false);
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                ball.RunBall();
                gameRunning = true;
            }

            if (Input.GetKeyDown(KeyCode.R))
            {
                ResetGame();
            }
        }
    }

    public void ResetGame()
    {
        SceneManager.LoadScene("Arkanoid");
    }

    public void EndGame(bool win)
    {
        gameRunning = false;

        string text = win ? "You win!" : "You lose!";
        Debug.Log(text);

        ball.StopBall();
    }
}
