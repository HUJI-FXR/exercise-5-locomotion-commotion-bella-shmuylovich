using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimYScript : MonoBehaviour
{
    #region VARIABLES

    [SerializeField] private float sensitivity;
    
    private float _xRotation = 0f;

    #endregion
    
    #region MONOBEHAVIOUR

    private void Update()
    {
        AimY();
    }

    #endregion

    #region HELPERS

    private void AimY()
    {
        var mouseY = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;
        _xRotation -= mouseY; 
        _xRotation = Mathf.Clamp(_xRotation, -90f, 90f);
        transform.localRotation = Quaternion.Euler(_xRotation, 0f, 0f);
    }

    #endregion
}
