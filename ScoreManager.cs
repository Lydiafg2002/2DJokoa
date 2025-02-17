using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public int score;

    public TextMeshProUGUI scoreText;
    private void Start()
    {
        score = PlayerPrefs.GetInt("score");
        //score = 0;
        scoreText.text = "Score: " + score;
    }

    private void Update()
    {
        //Puntuazio zenbaki batera heltzerakoan "YOU WIN" pantaila
    }

    public void GainPoints()
    {
        score++;
        scoreText.text = "Score: " + score;
        PlayerPrefs.SetInt("score", score);
        PlayerPrefs.Save();
    }

    public void LosePoints()
    {
        score--;
        if (score < 0)
        {
            score = 0;
        }
        scoreText.text = "Score: " + score;

    }
}
