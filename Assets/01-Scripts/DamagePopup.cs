using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DamagePopup : MonoBehaviour
{
    [SerializeField] Canvas Canvas;
    [SerializeField] TMP_Text DamageText;

    void Start()
    {
        Canvas.worldCamera = Camera.main;
        Destroy(gameObject, 5);
    }

    public void SetText(int value)
    {
        DamageText.text = value.ToString();
    }
}
