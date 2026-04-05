using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    Slider slider;
    public Gradient gradient;
    [SerializeField] Image fill;

    public static HealthBar Instance;

    //Using Singleton Pattern to use this script from PlayerHealth
    void Awake()
    {
        Instance = this;
        slider = GetComponent<Slider>();
    }
    
    public void SetMaxHealth(float value)
    {
        slider.maxValue = value;
        slider.value = value;

        fill.color = gradient.Evaluate(1f);
    }

    public void SetHealth(float value)
    {
        slider.value = value;

        //Setting the color of the healthbar according to the gradient color
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}
