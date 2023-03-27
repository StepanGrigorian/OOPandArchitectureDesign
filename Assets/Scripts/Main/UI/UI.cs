using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{
    public static UI instance;

    [SerializeField] ModulesMenu WeaponSelectionMenu;
    [SerializeField] ModulesMenu BuffSelectionMenu;

    [SerializeField] GameObject EndScreen;
    [SerializeField] TextMeshProUGUI EndScreenText;
    [SerializeField] string EndScreenTextFormat;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            throw new System.Exception();
        }
    }
    private void Start()
    {
        InitModules();
    }
    private void InitModules()
    {
        List<Module> weapons = new List<Module>();
        List<Module> buffs = new List<Module>();
        foreach (var item in Game.instance.GetModulesSO().Modules)
        {
            switch (item.GetMyType()) 
            { 
                case SlotType.Weapon:
                    weapons.Add(item);
                    break;
                case SlotType.Buff:
                    buffs.Add(item);
                    break;
            }
        }
        BuffSelectionMenu.InitContent(buffs);
        WeaponSelectionMenu.InitContent(weapons);
    }
    public void SelectWeapon()
    {
            HideAllMenues();
            WeaponSelectionMenu.gameObject.SetActive(true);
    }
    public void SelectBuff()
    {
        HideAllMenues();
        BuffSelectionMenu.gameObject.SetActive(true);
    }
    public void HideAllMenues()
    {
        WeaponSelectionMenu.gameObject.SetActive(false);
        BuffSelectionMenu.gameObject.SetActive(false);
    }
    public void StartGame()
    {
        Game.instance.StartGame();
    }
    public void StopGame()
    {
        SceneManager.LoadScene(0);
    }
    public void ShowEndScreen(string winnerName)
    {
        EndScreen.SetActive(true);
        EndScreenText.text = string.Format(EndScreenTextFormat, winnerName);
    }
}