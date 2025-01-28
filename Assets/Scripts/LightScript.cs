using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class LightScript : MonoBehaviour
{
    public Light Roomlight;
    public InputActionReference changeColor;
    private bool isGreen = false;
    // Start is called before the first frame update

    void OnEnable()
    {
        changeColor.action.Enable();
        changeColor.action.performed += LightToggle;
    }

    void OnDisable()
    {
        changeColor.action.Disable();
    }

    void LightToggle(InputAction.CallbackContext context)
    {
        if (isGreen)
        {
            Roomlight.color = Color.white;
        }
        else
        {
            Roomlight.color = Color.green;
        }
        
        isGreen = !isGreen;
    }

    void Start()
    {
        Roomlight = GetComponent<Light>();
        changeColor.action.Enable();

    }
}
