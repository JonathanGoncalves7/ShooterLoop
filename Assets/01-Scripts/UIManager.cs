using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] PlayerStatusSO PlayerStatus;

    [SerializeField] SliderBar Health;
    [SerializeField] SliderBar Mana;

    private void Start()
    {
        Health.SetMax(PlayerStatus.GetMaxHealth());
        Mana.SetMax(PlayerStatus.GetMaxMana());
    }

    private void Update()
    {
        Health.SetCurrent(PlayerStatus.CurrentHealth);
        Mana.SetCurrent(PlayerStatus.CurrentMana);
    }
}