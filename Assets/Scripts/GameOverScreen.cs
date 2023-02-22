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
        SceneManager.LoadScene("MainMenu");
        Destroy(BGmusic.instance);
        Destroy(Click.instance);
    }
}
