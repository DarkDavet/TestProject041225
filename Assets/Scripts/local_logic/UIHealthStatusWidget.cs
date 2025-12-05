using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHealthStatusWidget : MonoBehaviour, IWidget
{
    [SerializeField] private Slider slider;
    [SerializeField] private Image fillImage;
    [SerializeField] private Image handeImage;
    public void InitWdget(int maxAmount)
    {
        slider.value = 0;
        slider.maxValue = maxAmount;
    }

    public void UpdatedWidget(int amount)
    {
        if (slider.value >= 0)
        {
            slider.value = amount;
        }
    }
}
