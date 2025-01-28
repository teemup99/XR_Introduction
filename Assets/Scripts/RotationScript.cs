using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public float rotationSpeed = 15f;
    public float tiltAngle = 15f;
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
        transform.Rotate(Vector3.right, tiltAngle * Time.deltaTime);
    }
}
