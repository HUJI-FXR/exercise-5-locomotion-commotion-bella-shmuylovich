using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.U2D;
using UnityEngine;
using Random = UnityEngine.Random;

public class MonsterControlScript : MonoBehaviour
{
    #region VARIABLES
    
    [SerializeField] private float monsterTime;
    [SerializeField] private float chasePlayerChance;
    [SerializeField] private float rotationSpeed;
    
    private MovementScript _movementScript;
    private Transform _playerTransform;
    private float _monsterTimer;
    private bool _chasePlayer = false;

    #endregion

    #region MONOBEHAVIOUR

    private void Start()
    {
        _movementScript = GetComponent<MovementScript>();
    }

    private void Update()
    {
        // update timer
        _monsterTimer += Time.deltaTime;
        if (_monsterTimer >= monsterTime)
        {
            monsterTime = 0f;
           _chasePlayer =  Random.Range(0f, 1f) < chasePlayerChance ? true : false;
        }

        if (_chasePlayer) ChasePlayer();
        else RandomMove();
    }

    #endregion

    #region API

    public void SetPlayerTransform(Transform trans)
    {
        _playerTransform = trans;
    }

    #endregion

    #region HELPERS

    private void ChasePlayer()
    {
        if (_playerTransform == null) return;
        Vector3 direction = (_playerTransform.position - transform.position).normalized;
        Quaternion targetRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, 
            rotationSpeed * Time.deltaTime);
        _movementScript.Move(transform.forward);
    }

    private void RandomMove()
    {
        float randomYrotation = Random.Range(-1f, 1f) * rotationSpeed * Time.deltaTime;
        transform.Rotate(0f, randomYrotation, 0f);
        _movementScript.Move(transform.forward);
    }

    #endregion
}
