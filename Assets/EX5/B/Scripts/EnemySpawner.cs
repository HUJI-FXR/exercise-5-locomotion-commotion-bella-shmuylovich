using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.AffordanceSystem.Receiver.Primitives;
using Random = UnityEngine.Random;

public class EnemySpawner : MonoBehaviour
{
    #region VARIABLES

    [SerializeField] private List<GameObject> enemyTypes;
    [SerializeField] private Vector4 spawnAreaLimits;
    [SerializeField] private Transform playerTransform;
    [SerializeField] private float spawnHeight;
    [SerializeField] private int maxEnemyCount;
    [SerializeField] private float spawnTime;
    [SerializeField] private float spawnChance;
    [SerializeField] public HighScoreScript highScoreScript;

    private int _enemyCount = 0;
    private float _spawnTimer = 0;
    private List<GameObject> enemies = new List<GameObject>();

    #endregion

    #region MONOBEHAVIOUR
    
    private void OnEnable()
    {
        EventManager.Instance.OnEnemyDeath += HandleEnemyDeath;
    }

    private void OnDisable()
    {
        EventManager.Instance.OnEnemyDeath -= HandleEnemyDeath;
    }

    private void Update()
    {
        // update timer
        _spawnTimer += Time.deltaTime;
        if (_spawnTimer > spawnTime && enemies.Count < maxEnemyCount)
        {
            _spawnTimer = 0;
            if (Random.Range(0f, 1f) < spawnChance) SpawnEnemy();
        }
    }

    #endregion

    #region HELPERS

    private void SpawnEnemy()
    {
        float x = Random.Range(spawnAreaLimits.x, spawnAreaLimits.y);
        float z = Random.Range(spawnAreaLimits.z, spawnAreaLimits.w);
        int type = (int)Random.Range(0, enemyTypes.Count - 0.01f);
        var enemy = Instantiate(enemyTypes[type], new Vector3(x, spawnHeight, z), Quaternion.identity);
        enemy.GetComponent<MonsterControlScript>().SetPlayerTransform(playerTransform);
        enemies.Add(enemy);
        _enemyCount++;
    }

    private void HandleEnemyDeath()
    {
        print("dead");
        _enemyCount--;
        if (_enemyCount <= 0 && enemies.Count >= maxEnemyCount) 
            highScoreScript.SetGameEndText(true);
    }

    #endregion
}
