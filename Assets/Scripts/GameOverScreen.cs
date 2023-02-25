using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    public Text scoreText;
    public AudioSource gameOverSoundEffect;
    public void Setup(int score)
    { 
        gameObject.SetActive(true);
        BGmusic.instance.GetComponent<AudioSource>().Pause();
        gameOverSoundEffect.Play();
        scoreText.text = "WYNIK: " + score.ToString();
    }

    public void RestartButton()
    {       
        SceneManager.LoadScene("Snake");
        BGmusic.instance.GetComponent<AudioSource>().Play();
    }
    
    public void ExitButton()
    {
        //! Usuwanie obiektów wcześniej ustawionych na DonDestroyOnLoad
        Destroy(BGmusic.instance.gameObject);  
        Destroy(Click.instance.gameObject);     
        SceneManager.LoadScene("MainMenu");       
    }
}
