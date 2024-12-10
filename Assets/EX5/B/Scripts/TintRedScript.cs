using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TintRedScript : MonoBehaviour
{
    #region VARIABLES

    private LifeTotalScript _lifeScript;
    private Material _newMaterial;
    private Renderer _renderer;

    #endregion
    #region MONOBEHAVIOR

    private void Start()
    {
        _renderer = GetComponentInChildren<Renderer>();
        Material originalMaterial = _renderer.material; 
        _newMaterial = Instantiate(originalMaterial); 
        _newMaterial.SetColor("_Color", Color.white);
        _renderer.material = _newMaterial; 
        _lifeScript = GetComponent<LifeTotalScript>();
    }

    private void Update()
    {
        var lifeTotalRatio = _lifeScript.LifeTotal / _lifeScript.InitialLifeTotal;
        _newMaterial.SetColor("_Color", lifeTotalRatio * Color.white + (1f - lifeTotalRatio) * Color.red);
    }

    #endregion
   
}
