using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class DamageScript : MonoBehaviour
{
    #region VARIABLES

    [SerializeField] private float minDamage;
    [SerializeField] private float maxDamage;
    [SerializeField] private string damageTag;

    #endregion

    #region MONOBEHAVIOUR

    private void OnCollisionEnter(Collision collision)
    {
        var col = collision.gameObject;
        if (col.CompareTag(damageTag))
        {
            col.GetComponent<LifeTotalScript>().Damage(Random.Range(minDamage, maxDamage));
            if (damageTag == "Player") EventManager.Instance.EnemyDied();
            Destroy(gameObject);
        }
    }

    #endregion
}
