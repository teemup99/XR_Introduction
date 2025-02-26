using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TeleportScript : MonoBehaviour
{
    public InputActionReference changePlace;
    public Transform startPos;
    public Transform pos1;
    public Transform pos2;
    public Transform pos3;
    public Transform pos4;
    public Transform xrRig;
    private bool starting = true;
    private bool place1 = false;
    private bool place2 = false;
    private bool place3 = false;
    private bool place4 = false;

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
        if (starting)
        {
            xrRig.position = pos1.position;
            xrRig.rotation = pos1.rotation;
            starting = false;
            place1 = true;
            return;         
        }
        if (place1)
        {
            xrRig.position = pos2.position;
            xrRig.rotation = pos2.rotation;
            place1 = false;
            place2 = true;
            return;
        }
        if (place2)
        {
            xrRig.position = pos3.position;
            xrRig.rotation = pos3.rotation;
            place2 = false;
            place3 = true;
            return;
        }
        if (place3)
        {
            xrRig.position = pos4.position;
            xrRig.rotation = pos4.rotation;
            place3 = false;
            place4 = true;
            return;
        }
        if (place4)
        {
            xrRig.position = startPos.position;
            xrRig.rotation = startPos.rotation;
            place4 = false;
            starting = true;
            return;
        }
    }
}
