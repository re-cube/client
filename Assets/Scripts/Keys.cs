using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Keys : MonoBehaviour
{
    public int g = 0;
    public int v ;
    // public KeyCode Up;
    // public KeyCode Down;
    void Start()
    {
        gameObject.GetComponent<InputField>().onValueChanged.AddListener(delegate { changingTheValue(gameObject.GetComponent<InputField>().text); });
    }

    void Update()
    {
        //  if (Input.GetKey(Up))
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            keyRight();

        }
        //else if (Input.GetKey(Down))
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            keyLeft();
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            keyUp();

        }
        //else if (Input.GetKey(Down))
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            keyDown();
        }
    }
    void changingTheValue(string text)
    {
        v= Convert.ToInt32(GameObject.Find("InputField").GetComponent<InputField>().text);
    }
    void keyRight()
    {
        int i = Convert.ToInt32(GameObject.Find("InputField").GetComponent<InputField>().text);
       
        
        if (g >= 0 && g < i)
        {
            for (int y = 0; y < v; y++)
            {
                for (int z = 0; z < i; z++)
                {
                    GameObject.Find("Cube_" + g + "_" + y + "_" + z).GetComponent<Renderer>().enabled = false;
                }

            }
        }
        g++;
        if (g < 0) { g = 0; }
        if (g > i) { g = i; }
    }
    void keyLeft()
    {
        int i = Convert.ToInt32(GameObject.Find("InputField").GetComponent<InputField>().text);
        g--;
        if (g < 0) { g = 0; }
        if (g > i) { g = i; }
        if (g >= 0 && g <= i)
        {
            for (int y = 0; y < v; y++)
            {
                for (int z = 0; z < i; z++)
                {
                    GameObject.Find("Cube_" + g + "_" + y + "_" + z).GetComponent<Renderer>().enabled = true;
                }

            }
        }
        
        
    }
    void keyDown()
    {
        int i = Convert.ToInt32(GameObject.Find("InputField").GetComponent<InputField>().text);
        v--;
        if (v < 0) { v = 0; }
        if (v >= 0 && v < i)
        {
            for (int x = g; x < i; x++)
            {
                for (int z = 0; z < i; z++)
                {
                    GameObject.Find("Cube_" + x + "_" + v + "_" + z).GetComponent<Renderer>().enabled = false;
                }

            }
        }
        
    }
    void keyUp()
    {
        int i = Convert.ToInt32(GameObject.Find("InputField").GetComponent<InputField>().text);
        
        if (v >= 0 && v < i)
        {
            for (int x = g; x < i; x++)
            {
                for (int z = 0; z < i; z++)
                {
                    GameObject.Find("Cube_" + x + "_" + v + "_" + z).GetComponent<Renderer>().enabled = true;
                }

            }
        }
        v++;
        
        if (v > i) { v = i; }


    }
}
