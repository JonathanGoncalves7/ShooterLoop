using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PowerupItem : MonoBehaviour
{
    [Header("Data")]
    [SerializeField] PowerupDataSO PowerupData;
    [SerializeField] GoldDataSO GoldData;

    [Header("UI")]
    [SerializeField] TMP_Text Value;
    [SerializeField] Button Buy;

    private void Start()
    {
        UpdateUI();
    }


    private void UpdateUI()
    {
        if (PowerupData.IsMaxLevel())
        {
            Value.text = "";
            Buy.interactable = false;
            Buy.GetComponentInChildren<TMP_Text>().text = "Max Level";
        }
        else
        {
            Value.text = PowerupData.GetValue().ToString();
            Buy.interactable = true;
            Buy.GetComponentInChildren<TMP_Text>().text = "Buy";
        }
    }

    public void OnClickBuy()
    {
        if (PowerupData.GetValue() > GoldData.GetAmount()) return;

        AudioManager.s_instance.PlayButtonClick();

        GoldData.Dec(PowerupData.GetValue());
        PowerupData.Inc();

        UpdateUI();
    }
}
