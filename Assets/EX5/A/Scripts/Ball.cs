using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    #region VARIABLES

    public float speed;

    #endregion

    #region MONOBEHAIOUR

    void Update()
    {
        transform.Translate(transform.forward * Time.deltaTime * speed, Space.World);
        if (transform.position.z <= Camera.main.transform.position.z)
        {
            FindObjectOfType<GameManager>().EndLife();
        }
    }

    #endregion

    #region API

    public void SelectionHandler() 
    {
        GameManager.score++;
        Debug.Log(GameManager.score);
        Destroy(gameObject);
    }

    #endregion
    
}
