using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TeleportScript : MonoBehaviour
{
    public InputActionReference changePlace;
    public Vector3 insidePos;
    public Vector3 outsidePos;
    public Transform xrRig;
    private bool isInside = true;

    void OnEnable()
    {
        changePlace.action.Enable();
        changePlace.action.performed += MovePos;
    }

    private void OnDisable()
    {
        changePlace.action.Disable();
    }

    private void MovePos(InputAction.CallbackContext context)
    {
        if (isInside)
        {
            xrRig.position = outsidePos;
        }
        else
        {
            xrRig.position = insidePos;
        }

        isInside = !isInside;
    }
}
