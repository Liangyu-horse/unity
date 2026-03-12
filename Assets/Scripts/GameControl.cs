using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameControl : MonoBehaviour
{
    public static GameControl instance;
    public GameObject gameOverText;
    public bool gameOver = false;
    public bool gameStarted = false;
    public Text scoreText;
    public Text highScoreText;
    private int score = 0;
    public float scrollSpeed = -1.5f;
    public bool toggle = false;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("m"))
        {
            ToggleSound();
        }
        if ((gameOver && Input.GetKeyDown(KeyCode.Space)))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            Destroy(GameObject.Find("Start"));
        }
    }

    public void BirdScored()
    {
        if (gameOver)
        {
            return;
        }
        score++;
        scoreText.text = "Score: " + score.ToString();
    }
    public void BirdDied()
    {
        if (score > PlayerPrefs.GetInt("highScoreText", 0))
        {
            PlayerPrefs.SetInt("highScoreText", score);
            //highScoreText.text = score.ToString();
        }
        gameOverText.SetActive(true);
        gameOver = true;
    }

    public void startGame()
    {
        gameStarted = true;
        Destroy(GameObject.Find("Start"));
        highScoreText.gameObject.SetActive(false);
        scoreText.gameObject.SetActive(true);
        Time.timeScale = 1;
    }

    public void ToggleSound()
    {
        toggle = !toggle;

        if (toggle)
            AudioListener.volume = 1f;

        else
            AudioListener.volume = 0f;
    }
}
