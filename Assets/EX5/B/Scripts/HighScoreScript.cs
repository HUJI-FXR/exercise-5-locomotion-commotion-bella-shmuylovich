using System;
using System.Collections;
using System.Collections.Generic;
using TMPro.TextMeshProUGUI;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;

public class HighScoreScript : MonoBehaviour
{
    #region VARIABLES

    [SerializeField] private ScoreScript scoreScript;
    [SerializeField] private TextMeshProUGUI endGameText;

    private TextMeshProUGUI _text;
    private float highScore;

    #endregion
    
    #region MONOBEHAVIOUR
    
    private void OnEnable()
    {
        EventManager.Instance.OnPlayerDeath += GameOver;
    }

    private void OnDisable()
    {
        EventManager.Instance.OnPlayerDeath -= GameOver;
    }

    private void Awake()
    {
        _text = GetComponent<TextMeshProUGUI>();
        if (PlayerPrefs.HasKey("HighScore"))
        {
            highScore = PlayerPrefs.GetInt("HighScore");
            _text.text = "HIGH SCORE: " + (int)highScore;
        }
        else
        {
            highScore = 0;
            PlayerPrefs.SetInt("HighScore", (int)highScore);
            _text.text = "HIGH SCORE: " + (int)highScore;
        }
    }

    #endregion

    #region API

    public void UpdateHighScore()
    {
        if (scoreScript.Score > highScore)
        {
            highScore = scoreScript.Score;
            PlayerPrefs.SetInt("HighScore", (int)highScore);
            _text.text = "HIGH SCORE: " + (int)highScore;
        } 
    }

    public void SetGameEndText(bool win)
    {
        endGameText.text = win ? "YOU WIN!" : "YOU LOSE!";
        endGameText.gameObject.SetActive(true);
    }

    #endregion

    #region HELPERS

    private void GameOver()
    {
        SetGameEndText(false);
    }

    #endregion
}
