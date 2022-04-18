using UnityEngine;
using UnityEngine.UI;

public class MagicButton : MonoBehaviour
{
    [SerializeField] MagicDataSO MagicData;
    [SerializeField] Image CooldownImage;

    private void Update()
    {
        if (MagicData.GetRestCooldown() > 0)
        {
            CooldownImage.fillAmount = MagicData.GetRestCooldown();
            CooldownImage.enabled = true;
        }
        else
        {
            CooldownImage.enabled = false;
        }
    }
}
