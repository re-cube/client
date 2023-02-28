using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Main Camera")
        {
            GetComponent<Renderer>().material.color = Color.red;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Main Camera")
        {
            GetComponent<Renderer>().material.color = Color.green;
        }
    }
    private void OnBecameVisible()
    {
        //Debug.Log(gameObject.name);
    }
}
