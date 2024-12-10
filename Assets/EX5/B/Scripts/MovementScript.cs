using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScript : MonoBehaviour
{
    #region VARIABLES

    [SerializeField] private float runningSpeed;
    [SerializeField] private float jumpingForce;

    private Rigidbody _rigidbody;
    private bool _isGrounded;

    #endregion

    #region MONOBEHAVIOUR

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground")) _isGrounded = true;
    }

    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.CompareTag("Ground")) _isGrounded = false;
    }

    #endregion

    #region API

    public void Move(Vector3 direction)
    {
        if (_isGrounded) _rigidbody.velocity = new Vector3(direction.x * runningSpeed * Time.deltaTime, 
            _rigidbody.velocity.y, direction.z * runningSpeed * Time.deltaTime);
    }
    
    public void Jump()
    {
        if (_isGrounded) _rigidbody.AddForce(Vector3.up * jumpingForce, ForceMode.Impulse); 
    }

    #endregion

}
