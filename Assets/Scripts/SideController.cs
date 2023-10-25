using Assets.Class;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SideController : MonoBehaviour
{
    public bool isAttached;
    void OnMouseDown()
    {
        if (!isAttached)
            return;
        var objects = getSideObjects();
        var list = new List<Way>();
        foreach (var obj in objects)
        {
            Vector3 target = new Vector3();

            switch (gameObject.name)
            {
                case "Side 1":
                    target = new Vector3(obj.transform.parent.transform.position.x, obj.transform.parent.transform.position.y - 1.5f, obj.transform.parent.transform.position.z);
                    break;
                case "Side 2":
                    target = new Vector3(obj.transform.parent.transform.position.x, obj.transform.parent.transform.position.y + 1.5f, obj.transform.parent.transform.position.z);
                    break;
                case "Side 3":
                    target = new Vector3(obj.transform.parent.transform.position.x - 1.5f, obj.transform.parent.transform.position.y, obj.transform.parent.transform.position.z);
                    break;
                case "Side 4":
                    target = new Vector3(obj.transform.parent.transform.position.x + 1.5f, obj.transform.parent.transform.position.y, obj.transform.parent.transform.position.z);
                    break;
                case "Side 5":
                    target = new Vector3(obj.transform.parent.transform.position.x, obj.transform.parent.transform.position.y, obj.transform.parent.transform.position.z + 1.5f);
                    break;
                case "Side 6":
                    target = new Vector3(obj.transform.parent.transform.position.x, obj.transform.parent.transform.position.y, obj.transform.parent.transform.position.z - 1.5f);
                    break;
            }
            list.Add(new Way(obj.transform.parent.transform, obj.transform.parent.position, target));
            obj.transform.parent.transform.position = Vector3.Lerp(obj.transform.parent.transform.position, target, 1);
            
        }
        MainController.addWay(list);

        objects.ForEach(x => x.GetComponent<Renderer>().enabled = false);
       MainController.UpdateAttacheds();
    }
    private void OnMouseEnter()
    {
        if (!isAttached)
            return;

        getSideObjects().ForEach(x => x.GetComponent<Renderer>().enabled = true);
    }
    private void OnMouseExit()
    {
        if (!isAttached)
            return;

        getSideObjects().ForEach(x => x.GetComponent<Renderer>().enabled = false);
    }

    private List<GameObject> getSideObjects()
    {
        var allobjects = FindObjectsOfType<GameObject>().Where(x => x.name == gameObject.name).ToList();

        var sideBySide = new List<GameObject>();

        if (gameObject.name == "Side 1" || gameObject.name == "Side 2")
        {
            sideBySide.AddRange(allobjects.Where(gO1 => gO1.transform.position.y == gameObject.transform.position.y));
        }
        if (gameObject.name == "Side 3" || gameObject.name == "Side 4")
        {
            sideBySide.AddRange(allobjects.Where(gO1 => gO1.transform.position.x == gameObject.transform.position.x));
        }
        if (gameObject.name == "Side 5" || gameObject.name == "Side 6")
        {
            sideBySide.AddRange(allobjects.Where(gO1 => gO1.transform.position.z == gameObject.transform.position.z));
        }
        return sideBySide;
    }
}
