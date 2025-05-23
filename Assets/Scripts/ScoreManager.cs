using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    public int currentScore = 0;
    public int highScore = 0;

    public Text currentScoreText;
    public Text highScoreText;

    private void Awake()
    {
        // Singleton simple para acceder fácil
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);

            // Carga high score guardado
            highScore = PlayerPrefs.GetInt("HighScore", 0);
            UpdateUI();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddScore(int amount)
    {
        currentScore += amount;

        if (currentScore > highScore)
        {
            highScore = currentScore;
            PlayerPrefs.SetInt("HighScore", highScore);
        }

        UpdateUI();
    }

    void UpdateUI()
    {
        if (currentScoreText != null)
            currentScoreText.text = "" + currentScore;

        if (highScoreText != null)
            highScoreText.text = "" + highScore;
    }

    public void ResetScore()
    {
        currentScore = 0;
        UpdateUI();
    }
}
