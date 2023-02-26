using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public AudioSource click;
    private void Start()
    {
        if (Click.instance.gameObject)
        {
            click = AudioSource.FindObjectOfType<AudioSource>();  
        }
        if(!PlayerPrefs.HasKey("snakeSpeed"))
        {
            PlayerPrefs.SetFloat("snakeSpeed", 15);          
        }
        else
        {
            Snake.speed = PlayerPrefs.GetFloat("snakeSpeed");
        }       
        if(!PlayerPrefs.HasKey("musicVolume"))
        {
            PlayerPrefs.SetFloat("musicVolume", 1);
        }
        else
        {
            AudioListener.volume = PlayerPrefs.GetFloat("musicVolume");
        }       
    }
    public void StartGame()
    {
        click.Play();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);      
    }
    public void PlayClick()
    {
        click.Play(); 
    }
    public void QuitGame()
    {
        click.Play();    
        Application.Quit();   
    }
}
