using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimXScript : MonoBehaviour
{
    #region VARIABLES

    [SerializeField] private float sensitivity;
    
    private float _yRotation = 0f;

    #endregion
    
    #region MONOBEHAVIOUR

    private void Update()
    {
        AimX();
    }

    #endregion

    #region HELPERS

    private void AimX()
    {
        var mouseX = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        _yRotation += mouseX;
        transform.rotation = Quaternion.Euler(0f, _yRotation, 0f);
    }

    #endregion
}
