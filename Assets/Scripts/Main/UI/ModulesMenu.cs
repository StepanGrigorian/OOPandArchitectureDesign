using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ModulesMenu : MonoBehaviour
{
    public Transform Content;
    public GameObject ModuleUI;

    private List<GameObject> items;
    public void InitContent(List<Module> modules)
    {
        items = new();
        foreach (var module in modules)
        {
            GameObject obj = Instantiate(ModuleUI, Content);
            items.Add(obj);
            ModuleUI moduleUI = obj.GetComponent<ModuleUI>();
            moduleUI.SetModule(module);
        }
    }
}