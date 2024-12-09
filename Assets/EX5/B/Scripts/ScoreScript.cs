using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreScript : MonoBehaviour
{
    #region VARIABLES
    
    public float Score = 0f;
    
    [SerializeField] private float comboBonus;
    [SerializeField] private HighScoreScript highScoreScript;
    
    private TextMeshProUGUI _text;
    private float _comboTimer;


    #endregion

    #region MONOBEHAVIOUR
    
    private void OnEnable()
    {
        EventManager.Instance.OnEnemyDeath += AddScore;
    }

    private void OnDisable()
    {
        EventManager.Instance.OnEnemyDeath -= AddScore;
    }

    private void Awake()
    {
        _text = GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        _text.text = "SCORE: " + (int)Score;
        _comboTimer += Time.deltaTime;
    }

    #endregion

    #region API

    public void AddScore()
    {
        Score += 1f + (int)(comboBonus / _comboTimer);
        _comboTimer = 0f;
        highScoreScript.UpdateHighScore();
    }

    #endregion
}
