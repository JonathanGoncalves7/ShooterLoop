using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager s_instance;

    [SerializeField] GameObject PausePanel;

    [SerializeField] TMP_Text WaveText;

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

        WaveText.text = $"WAVE: {GameManager.s_instance.GetCurrentWave().ToString()}";
    }

    public void ShowDamagePopup(int value, Vector3 position)
    {
        GameObject newPopup = Instantiate(DamagePopup, position, Quaternion.identity);

        DamagePopup damagePopup = newPopup.GetComponent<DamagePopup>();
        damagePopup.SetText(value);
    }

    public void OnPauseClick()
    {
        AudioManager.s_instance.PlayButtonClick();

        Time.timeScale = 0f;
        PausePanel.SetActive(true);
    }

    public void OnResumoClick()
    {
        AudioManager.s_instance.PlayButtonClick();

        Time.timeScale = 1f;
        PausePanel.SetActive(false);
    }
}