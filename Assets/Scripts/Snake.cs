using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Snake : MonoBehaviour
{
    private Vector2 input;
    private bool play = true;
    private Vector2 direction = Vector2.right;
    private List<Transform> segments = new List<Transform>();
    public Transform segmentPrefab;
    public int initialSize = 4;
    public static float speed;
    private float nextUpdate;
    public Text scoreText;
    public GameOverScreen GameOverScreen;
    public AudioSource growSoundEffect;
    private bool moveleft;
    private bool moveright;

    private int score = 0;
    private void Start() {   
        if (speed == 0)
        {
            speed = 5;
        } 
        ResetState();
        PrintScore(score);
    }
    private void Update()
    {
        // Możliwość skręcania w górę/dół gdy porusza się w lewo/prawo
        if (direction == Vector2.right)
        {
            if (moveleft)
            {
                input = Vector2.up;
                moveleft = false;
            } 
            else if (moveright)
            {
                input = Vector2.down;
                moveright = false;
            }
        }
        if (direction == Vector2.left)
        {
            if (moveleft)
            {
                input = Vector2.down;
                moveleft = false;
            } 
            else if (moveright)
            {
                input = Vector2.up;
                moveright = false;
            }
        }
        // Możliwość skręcania w lewo/prawo gdy porusza się góra/dół
        if (direction == Vector2.up)   
        {
            if (moveleft)
            {
                input = Vector2.left;
                moveleft = false;
            }
            else if (moveright)
            {
                input = Vector2.right;
                moveright = false;
            }
        }
        if (direction == Vector2.down)   
        {
            if (moveleft)
            {
                input = Vector2.right;
                moveleft = false;
            }
            else if (moveright)
            {
                input = Vector2.left;
                moveright = false;
            }
        }   
        
    }

    private void FixedUpdate()
    {
        if (play == true)
        {
            if (input != Vector2.zero)
            {
                direction = input;
            }
            // Poczekaj na kolejny update przed postępowaniem dalej
            if (Time.time < nextUpdate)
            {
                return;
            }

            for (int i = segments.Count - 1; i > 0; i--)
            {
                segments[i].position = segments[i - 1].position;
            }

            float x = Mathf.Round(transform.position.x) + direction.x;
            float y = Mathf.Round(transform.position.y) + direction.y;

            transform.position = new Vector2(x, y);
            nextUpdate = Time.time + (1f / speed );
        }       
    }
    public void moveLeft()
    {
        moveleft = true;
    }
    public void moveRight()
    {
        moveright = true;
    }

    private void Grow()
    {
        Transform segment = Instantiate(this.segmentPrefab);
        segment.position = segments[segments.Count - 1].position;
        segments.Add(segment);
        // Wynik
        score += 1;    
        PrintScore(score);  
        // dźwięk
        growSoundEffect.Play();
    }
    private void ResetState()
    {
        for (int i = 1; i < segments.Count; i++)
        {
            Destroy(segments[i].gameObject);
        }

        segments.Clear();
        segments.Add(this.transform);

        for (int i = 1; i < this.initialSize; i++)
        {
            segments.Add(Instantiate(this.segmentPrefab));
        }
        score = 0;
        PrintScore(score);
        this.transform.position = Vector2.zero;                
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Food"){

            Grow();
        }
        else if (other.tag == "Obstacle"){
            GameOverScreen.Setup(score);
            play = false;        
        }        
    }
    
    private void PrintScore(int score)
    {
        scoreText.text = "Wynik: " + score.ToString();
    }
    public bool Occupies(float x, float y)
    {
        foreach (Transform segment in segments)
        {
            if (segment.position.x == x && segment.position.y == y)
            {
                return true;
            }
        }
        return false;
    }
}
