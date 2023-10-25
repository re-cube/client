using Assets.Class;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class MainController : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject cubePrefab;
    public float spacing = 0.5f;
    public static List<Ways> ways = new List<Ways>();

    private int size = 3;

    void Start()
    {
        int k = 0;
        for (int x = 0; x < size; x++)
        {
            for (int y = 0; y < size; y++)
            {
                for (int z = 0; z < size; z++)
                {
                    Vector3 spawnPosition = new Vector3(x * (spacing + 1), y * (spacing + 1), z * (spacing + 1));
                    var cube = Instantiate(cubePrefab, spawnPosition, Quaternion.identity);
                    cube.name = (++k).ToString();

                }
            }
        }
        UpdateAttacheds();
        //StartCoroutine(UpdateAttacheds());
    }
    private void Update()
    {
        if (Input.GetKey(KeyCode.LeftControl) && Input.GetKeyDown(KeyCode.Z))
        {
            if (ways.Count == 0)
                return;

            var last = ways.Last();

            last.Way.ForEach(x => x.Transform.position = Vector3.Lerp(x.ToPosition, x.FromPosition, 1f));
            ways.Remove(last);
            UpdateAttacheds();
        }

    }
    public static void addWay(List<Way> transforms)
    {
        ways.Add(new Ways(transforms));
    }
    public static void UpdateAttacheds()
    {

        var allSides = FindObjectsOfType<GameObject>().Where(x => x.name.StartsWith("Side")).ToList();
        var allSides2 = allSides;

        foreach (var side in allSides2)
        {
            if (allSides.Any(x => x.name != side.name && (x.transform.position - side.transform.position).magnitude < 0.05f && x.GetComponent<SideController>().isAttached == false))
            {
                side.GetComponent<SideController>().isAttached = true;
            }
            else
            {
                side.GetComponent<SideController>().isAttached = false;
            }
            //  yield return null;
        }
    }
}
