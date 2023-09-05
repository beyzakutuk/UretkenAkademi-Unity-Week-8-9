using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanSayac : MonoBehaviour
{
    public AudioClip scoreClip;
    public AudioClip bangClip;
    private AudioSource audioSource;

    public float count = 20;
    
    void Start()
    {
        PlayerPrefs.SetFloat("can", count);
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision other)
    {
        string _tag = other.gameObject.tag;
        if(_tag.Equals("duvar"))
        {
            count -= 1;

            audioSource.PlayOneShot(bangClip);

            PlayerPrefs.SetFloat("can" , count);
        }
        else if(_tag.Equals("can"))
        {
            count += 1;

            audioSource.PlayOneShot(scoreClip);

            Destroy(other.gameObject);
            PlayerPrefs.SetFloat("can", count);
        }
    }


}
