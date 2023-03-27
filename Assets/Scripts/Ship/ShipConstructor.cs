using UnityEngine;

public class ShipConstructor : MonoBehaviour
{
    private Slot currentSlot;
    public void SetCurrentSlot(Slot slot)
    {
        currentSlot = slot;
    }
    public void ApplyModule(Module mod)
    {
        if (currentSlot != null)
        {
            var obj = Instantiate(mod.MyPrefab, currentSlot.transform);
            Module module = obj.GetComponent<Module>();
            module.InitModule(currentSlot);
            currentSlot.used = true;
            currentSlot = null;
            UI.instance.HideAllMenues();
        }
    }
}