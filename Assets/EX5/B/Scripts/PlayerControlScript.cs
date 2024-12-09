using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControlScript : MonoBehaviour
{
    #region VARIABLES

    private MovementScript _movementScript;

    #endregion

    #region MONOBEHAVIOUR

    private void Start()
    {
        _movementScript = GetComponent<MovementScript>();
    }

    private void Update()
    {
        GetInput();
    }

    #endregion

    #region HELPERS

    private void GetInput()
    {
        // check movement
        if (Input.GetKey(KeyCode.W)) _movementScript.Move(transform.forward);
        if (Input.GetKey(KeyCode.A)) _movementScript.Move(-transform.right);
        if (Input.GetKey(KeyCode.S)) _movementScript.Move(-transform.forward);
        if (Input.GetKey(KeyCode.D)) _movementScript.Move(transform.right);
        // check jump
        if (Input.GetKey(KeyCode.Space)) _movementScript.Jump();
    }

    #endregion
}
