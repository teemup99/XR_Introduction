using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BallReset : MonoBehaviour
{
    public Transform ballTransform;
    public InputActionReference resetBall;
    public Transform resetPosition;
    private bool shouldReset = false;
    // Start is called before the first frame update
    private void OnEnable()
    {
        resetBall.action.Enable();
    }

    private void OnDisable()
    {
        resetBall.action.Disable();
    }

    void Update()
    {
        if (resetBall.action.triggered)
        {
            shouldReset = true;
        }
    }

    private void FixedUpdate()
    {
        if (shouldReset)
        {
            ResetBallPosition();
            shouldReset = false;
        }
    }

    void ResetBallPosition()
    {
        if (ballTransform != null)
        {
            Rigidbody rb = ballTransform.GetComponent<Rigidbody>();
            rb.isKinematic = false;
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
            rb.MovePosition(resetPosition.position);
            rb.MoveRotation(resetPosition.rotation);
            //rb.isKinematic = false;
        }
    }
}
