using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ShopManager : MonoBehaviour
{
    [SerializeField] GoldDataSO GoldData;
    [SerializeField] TMP_Text Gold;

    private void Update()
    {
        Gold.text = GoldData.GetAmount().ToString();
    }

    public void OnClickMenu()
    {
        SceneManager.LoadScene(0);
    }
}
