using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CubeCreate : MonoBehaviour
{
    // Start is called before the first frame update
    public void onClick()
    {
        int i = Convert.ToInt32(GameObject.Find("InputField").GetComponent<InputField>().text);
        for (int x = 0; x < i; x++)
        {
            for (int y = 0; y < i; y++)
            {
                for (int z = 0; z < i; z++)
                {
                    GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    cube.transform.position = new Vector3(x, y, z) * 1.1f;
                    cube.name = "Cube_" + x +"_" + y+"_" + z;
                }
            }
        }
        

    }
}
