using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    private Rigidbody rb;
    public float speed = 1.5f;
    bool _continue = true;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if(_continue)
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
    }

    private void OnCollisionEnter(Collision other)
    {
        string _tag = other.gameObject.tag;
        if(_tag.Equals("finishLine"))
        {
            print("Oyunu Kazandiniz");
            _continue = false;
        }
    }
}
