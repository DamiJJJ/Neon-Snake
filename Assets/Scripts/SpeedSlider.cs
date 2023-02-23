using UnityEngine;
using UnityEngine.UI;

public class SpeedSlider : MonoBehaviour
{
    public Slider speedSlider;
    private Text textSliderValue;
    public void Start()
    {       
        if(!PlayerPrefs.HasKey("snakeSpeed"))
        {
            PlayerPrefs.SetFloat("snakeSpeed", 15);
            Load();           
        }
        else
        {
            Load();    
        }            
        textSliderValue = GetComponent<Text>();
        ShowSliderValue();
    }
    public void ShowSliderValue()
    {
        string sliderMessage = speedSlider.value.ToString();
        textSliderValue.text = sliderMessage;
    }
    public void ChangeSpeed()
    {
        Snake.speed = speedSlider.value;
        Save();
    }

    private void Load()
    {
        speedSlider.value = PlayerPrefs.GetFloat("snakeSpeed");
    }

    private void Save()
    {
        PlayerPrefs.SetFloat("snakeSpeed", speedSlider.value);
    }
}

