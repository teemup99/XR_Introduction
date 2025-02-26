using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CustomGrab : MonoBehaviour
{
    // This script should be attached to both controller objects in the scene
    // Make sure to define the input in the editor (LeftHand/Grip and RightHand/Grip recommended respectively)
    CustomGrab otherHand = null;
    public List<Transform> nearObjects = new List<Transform>();
    public Transform grabbedObject = null;
    public InputActionReference action;
    bool grabbing = false;

    // Variables
    private Vector3 currentPosition;
    private Quaternion currentRotation;

    // Object snapping
    public List<Transform> snapPoints = new List<Transform>();
    public float snapDistance = 0.2f;
    public bool snapRotation = true;

    private void Start()
    {
        action.action.Enable();

        // Find the other hand
        foreach (CustomGrab c in transform.parent.GetComponentsInChildren<CustomGrab>())
        {
            if (c != this)
                otherHand = c;
        }
    }

    void Update()
    {
        grabbing = action.action.IsPressed();
        if (grabbing)
        {
            // Grab nearby object or the object in the other hand
            if (!grabbedObject)
            {
                grabbedObject = nearObjects.Count > 0 ? nearObjects[0] : otherHand.grabbedObject;

                if (grabbedObject)
                {
                    SnapToClosestPoint(grabbedObject);
                    //Code for bouncy ball
                    if (grabbedObject.name == "SuperBall")
                    {
                        Rigidbody rb = grabbedObject.GetComponent<Rigidbody>();
                        if (rb && !rb.isKinematic)
                        {
                            rb.isKinematic = true;
                            rb.useGravity = false;
                            rb.interpolation = RigidbodyInterpolation.None;
                        }
                    }
                }
            }

            if (grabbedObject)
            {
                // Change these to add the delta position and rotation instead
                // Save the position and rotation at the end of Update function, so you can compare previous pos/rot to current here
                Vector3 deltaPosition = transform.position - currentPosition;
                Quaternion deltaRotation = transform.rotation * Quaternion.Inverse(currentRotation);

                grabbedObject.position += deltaPosition;
                //grabbedObject.rotation = transform.rotation * Quaternion.Inverse(currentRotation) * grabbedObject.rotation;
                grabbedObject.rotation = deltaRotation * grabbedObject.rotation;
            }
        }
        // If let go of button, release object
        else if (grabbedObject)
        {
            // Throwing script
            Rigidbody rb = grabbedObject.GetComponent<Rigidbody>();
            if (rb && rb.isKinematic && grabbedObject.name == "SuperBall")
            {
                rb.isKinematic = false;
                rb.velocity = (transform.position - currentPosition) / Time.deltaTime;
                rb.angularVelocity = (transform.rotation.eulerAngles - currentRotation.eulerAngles) / Time.deltaTime;
                rb.useGravity = true;
                rb.interpolation = RigidbodyInterpolation.Interpolate;
            }
            grabbedObject = null;
        }

        // Should save the current position and rotation here
        currentPosition = transform.position;
        currentRotation = transform.rotation;
    }

    private void OnTriggerEnter(Collider other)
    {
        // Make sure to tag grabbable objects with the "grabbable" tag
        // You also need to make sure to have colliders for the grabbable objects and the controllers
        // Make sure to set the controller colliders as triggers or they will get misplaced
        // You also need to add Rigidbody to the controllers for these functions to be triggered
        // Make sure gravity is disabled though, or your controllers will (virtually) fall to the ground

        Transform t = other.transform;
        if (t && t.tag.ToLower() == "grabbable")
            nearObjects.Add(t);
    }

    private void OnTriggerExit(Collider other)
    {
        Transform t = other.transform;
        if (t && t.tag.ToLower() == "grabbable")
            nearObjects.Remove(t);
    }

    //Snapping script
    private void SnapToClosestPoint(Transform obj)
    {
        Transform closestSnap = null;
        float closestDistance = snapDistance;

        foreach (Transform snap in snapPoints)
        {
            float distance = Vector3.Distance(obj.position, snap.position);
            if (distance < closestDistance)
            {
                closestDistance = distance;
                closestSnap = snap;
            }
        }

        if (closestSnap)
        {
            obj.position = closestSnap.position;
            if (snapRotation)
            {
                obj.rotation = closestSnap.rotation;
            }
        }
    }
}
