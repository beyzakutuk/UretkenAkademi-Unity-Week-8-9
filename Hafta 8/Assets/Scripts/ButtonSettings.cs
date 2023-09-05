using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonSettings : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public GameObject StartPanel;
    public GameObject FinishPanel;
    public GameObject RetryPanel;
    public GameObject VolumePanel;

    public void PlayOnClick()
    {
        StartPanel.gameObject.SetActive(false);
    }

    public void ReplayOnClick()
    {
        SceneManager.LoadScene(0);
    }

    public void RetryOnClick()
    {
        SceneManager.LoadScene(0);
    }

    public void SoundOnClick()
    {
        VolumePanel.gameObject.SetActive(true);
    }

    public void CloseOnClick()
    {
        VolumePanel.gameObject.SetActive(false);
    }
}
