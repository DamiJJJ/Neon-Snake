using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    public Text scoreText;
    public void Setup(int score)
    {
        gameObject.SetActive(true);
        scoreText.text = "WYNIK: " + score.ToString();
    }

    public void RestartButton()
    {
        SceneManager.LoadScene("Snake");
    }
    
    public void ExitButton()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
