using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private void Start()
    {
        if(!PlayerPrefs.HasKey("snakeSpeed"))
        {
            PlayerPrefs.SetFloat("snakeSpeed", 15);          
        }
        Snake.speed = PlayerPrefs.GetFloat("snakeSpeed");
        if(!PlayerPrefs.HasKey("musicVolume"))
        {
            PlayerPrefs.SetFloat("musicVolume", 1);
        }
        AudioListener.volume = PlayerPrefs.GetFloat("musicVolume");
    }
    public void QuitGame()
    {
        Debug.Log("Game closed");      
        Application.Quit();   
    }

    public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);      
    }
}
