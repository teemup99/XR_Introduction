using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LensCamera : MonoBehaviour
{
    public Transform xrCamera; //original camera reference
    public Camera magCamera; //magnifying lens camera
    public float magnifyFOV = 20f;

    private void Start()
    {
        magCamera.fieldOfView = magnifyFOV;
    }
    // Update is called once per frame
    void Update()
    {
        Quaternion xrRotation = xrCamera.rotation;
        transform.rotation = Quaternion.Euler(xrRotation.eulerAngles.x, xrRotation.eulerAngles.y, 0f);
    }
}
