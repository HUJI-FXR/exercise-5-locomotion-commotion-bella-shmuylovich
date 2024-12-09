using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    #region VARIABLES

    public GameObject ballPrefab;
    public static int score = 0;
    public static int _livesLeft = 2;

  
    private int _waveNumber = 0;
    private int _highScore = 0;

    #endregion

    #region MONOBEHAVIOUR

    void Start()
    {
        if (_highScore == 0) 
        {
            _highScore = PlayerPrefs.GetInt("highScore", 0);
            Debug.Log("High Score is: " + _highScore);
        }
        SpawnMoreAndMore();
    }

    #endregion

    #region API

    public void EndLife()
    {
        if (_livesLeft <= 0) 
        {
            Debug.Log("Game Over! You scored " + score);
            if (score > _highScore) 
            {
                Debug.Log("New High Score!!!");
                _highScore = score;
                PlayerPrefs.SetInt("highScore", _highScore);
            }
            _livesLeft = 2;
            score = 0;
        }
        else {
            _livesLeft--;
            Debug.Log("Oops! You have " + _livesLeft + "lives left");
        }
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    #endregion

    #region HELPERS

    private void SpawnMoreAndMore()
    {
        if (_waveNumber > 10) 
        {
            return;
        }
        _waveNumber += 2;
        for (int i = 0; i < _waveNumber; i++)
        {
            SpawnOne();
        }
        Invoke("SpawnMoreAndMore", 3);
    }

    private void SpawnOne() 
    {
        GameObject newlyCreated = Object.Instantiate(ballPrefab);
        newlyCreated.transform.position = new Vector3(Random.Range(-10, 10), Random.Range(-10, 10), Random.Range(7, 17));
        newlyCreated.transform.LookAt(Camera.main.transform);
    }

    #endregion

}
