using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public Text time, healty;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time.text = (int)PlayerPrefs.GetFloat("timeCount") + "";
        healty.text = (int)PlayerPrefs.GetFloat("can") + "";
    }
}
