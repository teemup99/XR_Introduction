using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallStop : MonoBehaviour
{
    public string noBounceTag = "NoBounce";
    private Rigidbody rb;
    public AudioSource audioSource;
    public AudioClip winSound;
    public float volume;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(noBounceTag))
        {
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
            audioSource.PlayOneShot(winSound, volume);
        }
    }
}
