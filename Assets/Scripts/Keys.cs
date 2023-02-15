using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Keys : MonoBehaviour
{
    int k = 0;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            keyRight();
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            keyLeft();
        }
    }

    void keyLeft()
    {
        int i = int.Parse(GameObject.Find("InputField").GetComponent<InputField>().text);
        ToggleCubes(true, i);
        k++;
        ToggleCubes(false, i);
    }

    void keyRight()
    {
        int i = int.Parse(GameObject.Find("InputField").GetComponent<InputField>().text);
        ToggleCubes(true, i);
        k--;
        ToggleCubes(false, i);
    }

    void ToggleCubes(bool value, int i)
    {
        if (k >= 1 && k <= i)
        {
            for (int y = 1; y <= i; y++)
            {
                for (int z = 1; z <= i; z++)
                {
                    GameObject.Find($"Cube_{k}_{y}_{z}").GetComponent<Renderer>().enabled = value;
                }
            }
        }
    }
