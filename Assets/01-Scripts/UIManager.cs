using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] PlayerStatusSO PlayerStatus;

    [SerializeField] TMP_Text Health;
    [SerializeField] TMP_Text Mana;

    private void Update()
    {
        Health.text = PlayerStatus.CurrentHealth.ToString();
        Mana.text = PlayerStatus.CurrentMana.ToString();
    }
}