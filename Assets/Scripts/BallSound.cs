using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSound : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip bounceSound;
    public float minVelocity; //Threshold
    public float volume;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.relativeVelocity.magnitude > minVelocity)
        {
            audioSource.PlayOneShot(bounceSound, volume);
        }
    }

}
