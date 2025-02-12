using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LensKeeper : MonoBehaviour
{
    //public Transform theLens;

    // Update is called once per frame
    void Update()
    {
        Vector3 currentRot = transform.rotation.eulerAngles;

        transform.rotation = Quaternion.Euler(currentRot.x, currentRot.y, 0f);
    }
}
