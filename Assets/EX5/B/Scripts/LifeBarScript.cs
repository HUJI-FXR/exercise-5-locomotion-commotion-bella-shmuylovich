using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LifeBarScript : MonoBehaviour
{
    #region VARIABLES

    [SerializeField] private LifeTotalScript lifeScript;

    private TextMeshProUGUI _text;

    #endregion

    #region MONOBEHAVIOUR

    private void Awake()
    {
        _text = GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        _text.text = "HP: " + (int)lifeScript.LifeTotal;
    }

    #endregion
}
