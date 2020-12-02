using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SpawnBar : MonoBehaviour
{
    public Slider slider;
    public Image fill;
    public TMP_Text txtValue;

    public void SetCurrentValue(float _value)
    {
        slider.value = _value;
        txtValue.text = _value.ToString();
    }

    public void SetMaxValue(float _value)
    {
        slider.maxValue = _value;
    }
}
