using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthBar : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public Image fill;
    public TMP_Text txtValue;

    public void SetMaxHealth(float _health)
    {
        slider.maxValue = _health;
        slider.value = _health;

        if (txtValue != null)
        {
            txtValue.text = _health.ToString() + " / " + _health.ToString();
        }        

        fill.color = gradient.Evaluate(1f);
    }
    
    public void SetHealth(float _health)
    {
        slider.value = _health;

        if (txtValue != null)
        {
            txtValue.text = _health.ToString() + " / " + slider.maxValue.ToString();
        }

        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
    
}
