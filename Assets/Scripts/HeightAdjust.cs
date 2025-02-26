using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class HeightAdjust : MonoBehaviour
{
    public Transform xrRig;
    public InputActionReference adjustHeight;
    public float increment = 0.05f;
    public float minHeight = 0.3f;
    public float maxHeight = 0.6f;
    private bool increasing = true;
    
    private void OnEnable()
    {
        adjustHeight.action.Enable();
    }

    private void OnDisable()
    {
        adjustHeight.action.Disable();
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (adjustHeight.action.triggered)
            AdjustHeight();
    }

    private void AdjustHeight()
    {
        Vector3 currentPos = xrRig.position;
        float newHeight;
        //set height
        if (increasing)
        {
            newHeight = currentPos.y + increment;
        }
        else
        {
            newHeight = currentPos.y - increment;
        }
        //direction toggle
        if (newHeight >= maxHeight)
        {
            newHeight = maxHeight;
            increasing = false;
        }
        else if (newHeight <= minHeight)
        {
            newHeight = minHeight;
            increasing = true;
        }

        xrRig.position = new Vector3(currentPos.x, newHeight, currentPos.z);
    }
}

