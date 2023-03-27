using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShipUI : MonoBehaviour
{
    [SerializeField] private Slider healthBar;
    [SerializeField] private TextMeshProUGUI healthText;
    [SerializeField] private Slider shieldBar;
    [SerializeField] private TextMeshProUGUI shieldText;
    public void UpdateUI(float curHealth, float health, float curShield, float shield)
    {
        healthBar.value = curHealth / health;
        healthText.text = Mathf.Round(curHealth).ToString();
        shieldBar.value = curShield / shield;
        shieldText.text = Mathf.Round(curShield).ToString();
    }
}