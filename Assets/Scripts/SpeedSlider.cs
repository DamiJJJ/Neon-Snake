using UnityEngine;
using UnityEngine.UI;

public class SpeedSlider : MonoBehaviour
{
    public Slider speedSlider;    
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

