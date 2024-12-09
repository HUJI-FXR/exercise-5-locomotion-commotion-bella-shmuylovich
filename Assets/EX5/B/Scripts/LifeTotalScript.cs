using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeTotalScript : MonoBehaviour
{
    #region VARIABLESz

    [SerializeField] public float InitialLifeTotal;
    
    public float LifeTotal { get; private set; }

    #endregion

    #region MONOBEHAVIOUR

    private void Awake()
    {
        LifeTotal = InitialLifeTotal;
    }

    #endregion

    #region API

    public void Damage(float damageAmount)
    {
        LifeTotal -= damageAmount;
        if (LifeTotal <= 0)
        {
            if (CompareTag("Enemy")) EventManager.Instance.EnemyDied();
            if (CompareTag("Player")) EventManager.Instance.PlayerDied();
            Destroy(gameObject);
        }
    }

    #endregion
}
