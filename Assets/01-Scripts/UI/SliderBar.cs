using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class SliderBar : MonoBehaviour
{
    Slider _Slider;

    private void Awake()
    {
        _Slider = GetComponent<Slider>();
    }

    public void SetMax(int value)
    {
        _Slider.minValue = 0;
        _Slider.maxValue = value;
    }

    public void SetCurrent(int value)
    {
        _Slider.value = value;
    }
}
