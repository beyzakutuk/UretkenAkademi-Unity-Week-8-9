using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollingSound : MonoBehaviour
{
    public AudioClip rollingSound;
    public AudioSource audio;

    private Rigidbody rb;
    public float rollingThreshold;
    public float rollingRate;
    private float lastRollingTime;
    public GameObject StartPanel;
    bool isRolling;

    private float minVolume = 0.1f; 
    private float maxVolume = 0.3f; 
    private float targetVolume; 

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audio = GetComponent<AudioSource>();
        isRolling = false;

        audio.volume = minVolume; 
        targetVolume = minVolume;
    }

    void Update()
    {
        if (rb.velocity.magnitude <= rollingThreshold)
        {
            // Top hareket etmiyorsa
            if (isRolling)
            {
                // Ses seviyesini yavaşça minimuma ayarla
                targetVolume = minVolume;
                isRolling = false;
            }
        }
    }

    private void FixedUpdate()
    {
        if(rb.velocity.magnitude > rollingThreshold)
        {

            if (!isRolling)
            {
                audio.PlayOneShot(rollingSound);
                isRolling = true;
            }

            if (Time.time - lastRollingTime > rollingRate)
            {
                lastRollingTime = Time.time;
                GetComponent<AudioSource>().PlayOneShot(rollingSound);
            }
            targetVolume = maxVolume;
        }
        
        audio.volume = Mathf.MoveTowards(audio.volume, targetVolume, Time.deltaTime * 2.0f);
    }
}
