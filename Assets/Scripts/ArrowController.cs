using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowController : MonoBehaviour
{
    void OnMouseDown()
    {
        Debug.Log(gameObject.name);
    }
    private void OnMouseEnter()
    {
        Debug.Log("here on mouse enter");
        
    }

}
