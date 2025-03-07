using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
   
    public int totalScore;
    public Text scoreText;

    public static GameController instance;

    public GameObject gameOver;


    void Start()
    {
        instance = this;
    }

    public void UpdateScoreText()
    {
        scoreText.text = totalScore.ToString();
    }

    public void showGameOver()
    {
        gameOver.SetActive(true);
    }

    public void RestartGame(string lvlname)
    {
        SceneManager.LoadScene(lvlname);
    }
}
