using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicZone : MonoBehaviour
{

    public AudioSource audio;
    public float fadeTime;
    private float targetVolume;

    void Start()
    {
        targetVolume = 0.0f;
        audio.volume = 0.0f;
    }

    void Update()
    {
        audio.volume = Mathf.MoveTowards(audio.volume, targetVolume, (1.0f / fadeTime)) * Time.deltaTime;
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            targetVolume = 1.8f;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            targetVolume = 0.0f;
        }
    }
}
