using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    private Rigidbody rb;
    public float speed = 1.5f;
    bool _continue=true;
    public float timeCount = 500;
    public GameObject StartPanel;
    public GameObject RetryPanel;
    public GameObject FinishPanel;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        PlayerPrefs.SetFloat("timeCount", timeCount);
    }

    // Update is called once per frame
    void Update()
    {
        if(_continue && !StartPanel.gameObject.activeSelf)
        {
            timeCount -= Time.deltaTime;
            PlayerPrefs.SetFloat("timeCount", timeCount);
            print(timeCount);
        }
        if(timeCount < 0)
        {
            _continue = false;
            RetryPanel.gameObject.SetActive(true);
        }
        
    }

    private void FixedUpdate()
    {
        if(_continue && !StartPanel.gameObject.activeSelf)
        {
            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");

            Vector3 kuvvet = new(z, 0, -1 * x);
            rb.AddForce(kuvvet * speed);

        }
        else
        {
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }
        if (PlayerPrefs.GetFloat("can") == 0)
        {
            _continue = false;
            RetryPanel.gameObject.SetActive(true);
        }
        

    }

    private void OnCollisionEnter(Collision other)
    {
        string _tag = other.gameObject.tag;
        if(_tag.Equals("finishLine"))
        {
            print("Oyunu Kazandiniz");
            _continue = false;
            FinishPanel.gameObject.SetActive(true);
        }
    }
}
