using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager s_instance;

    [SerializeField] SliderBar Health;
    [SerializeField] SliderBar Mana;

    [SerializeField] GameObject DamagePopup;

    private void Awake()
    {
        s_instance = this;
    }

    private void Start()
    {
        Health.SetMax(GameManager.s_instance.PlayerStatus.GetMaxHealth());
        Mana.SetMax(GameManager.s_instance.PlayerStatus.GetMaxMana());
    }

    private void Update()
    {
        Health.SetCurrent(GameManager.s_instance.PlayerStatus.CurrentHealth);
        Mana.SetCurrent(GameManager.s_instance.PlayerStatus.CurrentMana);
    }

    public void ShowDamagePopup(int value, Vector3 position)
    {
        GameObject newPopup = Instantiate(DamagePopup, position, Quaternion.identity);

        DamagePopup damagePopup = newPopup.GetComponent<DamagePopup>();
        damagePopup.SetText(value);
    }
}