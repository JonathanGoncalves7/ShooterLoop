using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ShopManager : MonoBehaviour
{
    [SerializeField] GoldDataSO GoldData;

    public void OnClickMenu()
    {
        SceneManager.LoadScene(0);
    }
}
