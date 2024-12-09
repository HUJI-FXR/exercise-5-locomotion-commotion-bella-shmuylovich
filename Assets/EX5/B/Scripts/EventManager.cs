using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Timeline.Actions;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    #region VARIABLES

    public static EventManager Instance { get; private set; }
    public event Action OnEnemyDeath;
    public event Action OnPlayerDeath;

    [SerializeField] private float eventCooldown;

    private float _coolDownTimer;
    private bool _canInvoke;
    #endregion

    #region MONOBEHAVIOUR

    private void OnEnable()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    private void Update()
    {
        _coolDownTimer += Time.deltaTime;
        if (_coolDownTimer > eventCooldown)
        {
            _coolDownTimer = 0f;
            _canInvoke = true;
        }
    }

    #endregion

    #region API

    public void EnemyDied()
    {
        if (_canInvoke)
        {
            _canInvoke = false;
            OnEnemyDeath?.Invoke();
        }
    }
    
    public void PlayerDied()
    {
        if (_canInvoke)
        {
            _canInvoke = false;
            OnPlayerDeath?.Invoke();
        }
    }

    #endregion
}
