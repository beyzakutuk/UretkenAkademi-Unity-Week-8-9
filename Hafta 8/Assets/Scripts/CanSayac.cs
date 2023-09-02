using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanSayac : MonoBehaviour
{
    public float count = 20;
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetFloat("can", count); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision other)
    {
        string _tag = other.gameObject.tag;
        if(_tag.Equals("duvar"))
        {
            count -= 1;
            PlayerPrefs.SetFloat("can" , count);
        }
        else if(_tag.Equals("can"))
        {
            Destroy(other.gameObject);
            count += 1;
            PlayerPrefs.SetFloat("can", count);
        }
    }


}
