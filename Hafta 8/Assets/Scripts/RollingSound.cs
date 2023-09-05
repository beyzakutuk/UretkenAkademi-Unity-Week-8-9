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

    // Bu değişkenler ses seviyesini kontrol etmek için kullanılacak.
    private float minVolume = 0.1f; // Minimum ses seviyesi
    private float maxVolume = 1.0f; // Maximum ses seviyesi
    private float targetVolume; // Hedef ses seviyesi

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audio = GetComponent<AudioSource>();
        isRolling = false;

        audio.volume = minVolume; // Başlangıçta minimum ses seviyesi
        targetVolume = minVolume;
    }

    void Update()
    {
        if (rb.velocity.magnitude <= rollingThreshold)
        {
            // Top hareket etmiyorsa ve daha önce hareket ediyorsa sesi durdur.
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
                // Top hareket etmeye başladığında sesi çal.
                audio.PlayOneShot(rollingSound);
                isRolling = true;
            }

            if (Time.time - lastRollingTime > rollingRate)
            {
                lastRollingTime = Time.time;
                GetComponent<AudioSource>().PlayOneShot(rollingSound);
            }
            // Ses seviyesini yavaşça maksimuma ayarla
            targetVolume = maxVolume;
        }
        // Ses seviyesini hedefe yavaşça yaklaştır
        audio.volume = Mathf.Lerp(audio.volume, targetVolume, Time.deltaTime * 2.0f);
    }
}
