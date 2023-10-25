using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ArrowUpper : MonoBehaviour
{
    public GameObject targetObject; // Объект, к которому нужно добавить скрипт
    public string scriptPath; // Путь к скрипту в папке "Assets"

    private void Start()
    {
        if (targetObject != null && !string.IsNullOrEmpty(scriptPath))
        {
            MonoBehaviour scriptToAdd = AssetDatabase.LoadAssetAtPath<MonoBehaviour>(scriptPath);

            if (scriptToAdd != null)
            {
                foreach (Transform child in targetObject.transform)
                {
                    child.gameObject.AddComponent(scriptToAdd.GetType());
                }
            }
            else
            {
                Debug.LogError("Script not found at path: " + scriptPath);
            }
        }
    }
}
