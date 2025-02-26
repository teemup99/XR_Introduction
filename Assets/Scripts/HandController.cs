using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class HandController : MonoBehaviour
{
    public InputActionReference grip;
    public InputActionReference trig;
    public InputActionReference thumb;
    public Hand hand;
    // Start is called before the first frame update
    void Start()
    {
        grip.action.Enable();
        trig.action.Enable();
        thumb.action.Enable();

    }

    // Update is called once per frame
    void Update()
    {
        hand.SetGrip(grip.action.ReadValue<float>());
        hand.SetTrigger(trig.action.ReadValue<float>());
        hand.SetThumb(thumb.action.ReadValue<float>());
    }
}
