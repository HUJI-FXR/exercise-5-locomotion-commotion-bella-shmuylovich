using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.InputSystem;

public class ShootyGunScript : MonoBehaviour
{
    #region VARIABLES

    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform spawnTransform;
    [SerializeField] private float bulletSpeed;
    [SerializeField] private GameObject rightController;
    
    private InputAction _shoot;

    #endregion

    #region MONOBEHAVIOUR

    private void OnEnable()
    {
        _shoot = new XRIDefaultInputActions().XRIRightHandInteraction.Activate;
        _shoot.Enable();
    }

    private void OnDisable()
    {
        _shoot.Disable();
    }

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        CheckInput();
    }

    #endregion

    #region HELPERS

    private void CheckInput()
    {
        if (_shoot.WasPressedThisFrame()) Shoot();
    }

    private void Shoot()
    {
        GameObject shot = Instantiate(bullet, spawnTransform.transform.position, spawnTransform.transform.rotation);
        shot.GetComponent<Rigidbody>().velocity = rightController.transform.forward * bulletSpeed * Time.deltaTime;
        Destroy(shot, 5f);
        // Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        // Vector3 targetPoint;
        // if (Physics.Raycast(ray, out RaycastHit hit))
        // {
        //     targetPoint = hit.point;
        // }
        // else
        // {
        //     targetPoint = ray.GetPoint(100f); 
        // }
        //
        // GameObject bulletObject = Instantiate(bullet, spawnTransform.position, Quaternion.identity);
        // Vector3 direction = (targetPoint - spawnTransform.position).normalized;
        // Rigidbody bulletRb = bulletObject.GetComponent<Rigidbody>();
        // if (bulletRb != null)
        // {
        //     bulletRb.velocity = direction * bulletSpeed;
        // }
        //
        // Destroy(bulletObject, 5f);
    }

    #endregion
}
