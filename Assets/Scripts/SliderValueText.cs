using UnityEngine;
using UnityEngine.UI;

public class SliderValueText : MonoBehaviour
{
    public Slider speedSlider;
    private Text textSliderValue;
    string sliderMessage;
    private void Awake()
    {
        speedSlider = GetComponentInParent<Slider>();
        textSliderValue = GetComponent<Text>();
    }
    private void Start() {
        ShowSliderValue(speedSlider.value);
        speedSlider.onValueChanged.AddListener(ShowSliderValue);
    }
    public void ShowSliderValue(float value)
    {
        sliderMessage = speedSlider.value.ToString();
        textSliderValue.text = sliderMessage;
    }
}
