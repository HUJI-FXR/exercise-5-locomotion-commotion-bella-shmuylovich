using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class TeleportManager : MonoBehaviour
{
#region VARIABLES

public TeleportationProvider teleportationProvider;
public static int teleportCounter;
public int allowedTeleports = 3;

#endregion

#region MONOBEHAVIOUR

    private void OnEnable()
    {
        teleportationProvider.endLocomotion += OnEndLocomotion;
    }

    private void OnDisable() 
    {
        teleportationProvider.endLocomotion -= OnEndLocomotion;
    }

    #endregion

    #region HELPERS

    void OnEndLocomotion(LocomotionSystem locomotionSystem) 
    {
        teleportCounter++;
        Debug.Log("Teleportation #" + teleportCounter + " has ended");

        if (teleportCounter > allowedTeleports)
        {
            teleportationProvider.enabled = false;
        }
    }

#endregion
}
