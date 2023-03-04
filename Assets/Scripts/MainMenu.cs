using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public AudioSource click;
    public Text version;
    private void Start()
    {
        version.GetComponent<Text>().text = "v." + Application.version;
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

    public void OpenGitHub()
    {
        Application.OpenURL("https://github.com/DamiJJJ/Neon-Snake");
    }
}
