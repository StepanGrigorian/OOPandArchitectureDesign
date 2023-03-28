using UnityEngine;
using UnityEngine.EventSystems;

public class Slot : MonoBehaviour
{
    [SerializeField] SlotType mySlotType;
    public Ship Parent;
    public bool used = false;
    private void OnMouseDown()
    {
        if(!used && !EventSystem.current.IsPointerOverGameObject())
        switch (mySlotType)
        {
            case SlotType.Weapon:
                Game.instance.OpenWeaponSelection(this);
                return;
            case SlotType.Buff:
                Game.instance.OpenModuleSelection(this);
                return;
        }
    }
}
public enum SlotType
{
    Weapon,
    Buff
}