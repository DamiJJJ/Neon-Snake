using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    public Text scoreText;
    public AudioSource gameOverSoundEffect;
    public Canvas Arrows;
    private AudioSource click;
    public void Setup(int score)
    { 
        Arrows.GetComponent<Canvas>().enabled = false;
        gameObject.SetActive(true);
        click = AudioSource.FindObjectOfType<AudioSource>();
        BGmusic.instance.GetComponent<AudioSource>().Pause();
        gameOverSoundEffect.Play();
        scoreText.text = "WYNIK: " + score.ToString();
    }

    public void RestartButton()
    {
        click.Play();       
        SceneManager.LoadScene("Snake");
        BGmusic.instance.GetComponent<AudioSource>().Play();
    }
    
    public void ExitButton()
    {
        click.Play();
        //! Usuwanie obiektów wcześniej ustawionych na DonDestroyOnLoad
        Destroy(BGmusic.instance.gameObject);      
        SceneManager.LoadScene("MainMenu");       
    }
}
