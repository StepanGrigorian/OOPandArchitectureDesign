using UnityEngine;

[RequireComponent(typeof(Ship))]
public class SimpleAI : MonoBehaviour
{
    public Ship myShip { get; private set; }
    [SerializeField] private Ship enemyShip;
    private void Awake()
    {
        myShip = GetComponent<Ship>();
    }
    public void Activate()
    {
        myShip.Activate();
        foreach (var weapon in myShip.Weapons)
        {
            weapon.SetTarget(enemyShip);
        }
    }
    public void Deactivate()
    {
        myShip.Deactivate();
    }
}