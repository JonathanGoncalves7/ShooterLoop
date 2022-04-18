using UnityEngine;
using UnityEngine.UI;

public class ConfigManager : MonoBehaviour
{
    [SerializeField] Slider BGM;
    [SerializeField] Slider SFX;

    private void Start()
    {
        BGM.value = AudioManager.s_instance.GetPPVolumeBGM();
        SFX.value = AudioManager.s_instance.GetPPVolumeSFX();
    }

    private void Update()
    {
        AudioManager.s_instance.ChangeBGMVolume(BGM.value);
        AudioManager.s_instance.ChangeSFXVolume(SFX.value);
    }
}
