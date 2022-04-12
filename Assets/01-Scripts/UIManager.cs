using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] SliderBar Health;
    [SerializeField] SliderBar Mana;

    [SerializeField] TMP_Text GoldText;

    private void Start()
    {
        Health.SetMax(GameManager.s_instance.PlayerStatus.GetMaxHealth());
        Mana.SetMax(GameManager.s_instance.PlayerStatus.GetMaxMana());
    }

    private void Update()
    {
        Health.SetCurrent(GameManager.s_instance.PlayerStatus.CurrentHealth);
        Mana.SetCurrent(GameManager.s_instance.PlayerStatus.CurrentMana);

        GoldText.text = GameManager.s_instance.GoldData.GetAmount().ToString();
    }
}