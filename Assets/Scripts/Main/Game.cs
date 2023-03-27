using UnityEngine;

public class Game : MonoBehaviour
{
    public static Game instance;
    [SerializeField] private ShipConstructor ShipConstructor;

    [SerializeField] private ModulesSO Modules;

    [SerializeField] private SimpleAI Ship1;
    [SerializeField] private SimpleAI Ship2;
    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            throw new System.Exception();
    }
    public ShipConstructor GetShipConstructor()
    {
        return ShipConstructor;
    }
    public ModulesSO GetModulesSO()
    {
        return Modules;
    }
    public void OpenWeaponSelection(Slot slot)
    {
        UI.instance.SelectWeapon();
        ShipConstructor.SetCurrentSlot(slot);
    }
    public void OpenModuleSelection(Slot slot)
    {
        UI.instance.SelectBuff();
        ShipConstructor.SetCurrentSlot(slot);
    }
    public void ApplyModule(Module module)
    {
        ShipConstructor.ApplyModule(module);
    }
    public void StartGame()
    {
        Ship1.Activate();
        Ship2.Activate();
        Ship1.myShip.OnLose += OnGameFinished;
        Ship2.myShip.OnLose += OnGameFinished;
    }
    public void OnGameFinished(Ship loser)
    {
        Ship1.Deactivate();
        Ship2.Deactivate();
        if(loser == Ship1.myShip)
        {
            UI.instance.ShowEndScreen(Ship2.myShip.name);
        }
        else
        {
            UI.instance.ShowEndScreen(Ship1.myShip.name);
        }
    }
}