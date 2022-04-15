using UnityEngine;
using TMPro;

public class GoldUI : MonoBehaviour
{
    [SerializeField] GoldDataSO GoldData;
    [SerializeField] TMP_Text GoldText;

    private void Start()
    {
        GoldText.text = GoldData.GetAmount().ToString();
    }

    private void OnEnable()
    {
        GoldData.OnGoldChanged += UpdateGold;
    }

    private void OnDisable()
    {
        GoldData.OnGoldChanged -= UpdateGold;
    }

    public void UpdateGold(int value)
    {
        GoldText.text = value.ToString();
    }
}
