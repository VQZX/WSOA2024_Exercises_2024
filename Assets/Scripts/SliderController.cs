using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SliderController : MonoBehaviour
{
    public float TimeInSeconds => slider.value;

    [SerializeField]
    private TMP_Text timeText;

    [SerializeField]
    private Slider slider;

    [SerializeField, Range(0.5f, 3)]
    private float minimumValue = 0.5f;

    [SerializeField, Range(2, 5)]
    private float maximumValue = 5f;
    
    
    public void SliderValueChange(float change)
    {
        var sliderValue = Mathf.Clamp(change, minimumValue, maximumValue);
        slider.value = sliderValue;
        timeText.text = $"{TimeInSeconds:0.00}";
    }

    private void Awake()
    {
        slider.value = Mathf.Clamp(slider.value, minimumValue, maximumValue);
        timeText.text = $"{TimeInSeconds:0.00}";
        slider.minValue = minimumValue;
        slider.maxValue = maximumValue;
    }
}
