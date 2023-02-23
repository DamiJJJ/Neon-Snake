using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private void Start()
    {
        Snake.speed = PlayerPrefs.GetFloat("snakeSpeed");
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
