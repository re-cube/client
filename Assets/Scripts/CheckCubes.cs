using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckCubes : MonoBehaviour
{
    Renderer[] renderers;

    void Awake()
    {
        GameObject cubes = this.gameObject;
        renderers = cubes.GetComponentsInChildren<Renderer>();
        
    }

    void Update()
    {
        OutputVisibleRenderers(renderers);
    }

    void OutputVisibleRenderers(Renderer[] renderers)
    {
        foreach (var renderer in renderers)
        {
            // output only the visible renderers' name
            if (IsVisible(renderer))
            {
                Debug.Log(renderer.name + " is detected!");
                GetComponent<Renderer>().material.color = Color.yellow;
            }
            else { GetComponent<Renderer>().material.color = Color.green; }
        }

        //Debug.Log("--------------------------------------------------");
    }

    private bool IsVisible(Renderer renderer)
    {
        Plane[] planes = GeometryUtility.CalculateFrustumPlanes(Camera.main);

        if (GeometryUtility.TestPlanesAABB(planes, renderer.bounds))
            return true;
        else
            return false;
    }
}