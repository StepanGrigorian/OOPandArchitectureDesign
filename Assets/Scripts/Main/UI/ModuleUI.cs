using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ModuleUI : MonoBehaviour
{
    public Image MyImage;
    public TextMeshProUGUI Name;
    public TextMeshProUGUI Description;
    public Button MyButton;

    public Module MyModule;
    public void SetModule(Module module)
    {
        MyModule = module;
        MyImage.sprite = module.MyIcon;
        Name.text = module.name;
        Description.text = module.Description;
        MyButton.onClick.AddListener(() => Game.instance.ApplyModule(module));
    }
}