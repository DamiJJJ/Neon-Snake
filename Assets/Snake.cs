using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake : MonoBehaviour
{
    private Vector2 input;
    private Vector2 direction = Vector2.right;
    private List<Transform> segments = new List<Transform>();
    public Transform segmentPrefab;
    public int initialSize = 4;
    public float speed = 20f;
    public float speedMultiplier = 1f;
    private float nextUpdate;

    private void Start() {
        ResetState();
    }
    private void Update()
    {
        // Możliwość skręcania w górę/dół gdy porusza się po osi x
        if (direction.x != 0f)
        {
            if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
            {
                input = Vector2.up;
            } 
            else if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
            {
                input = Vector2.down;
            }
        }
        // Możliwość skręcania w lewo/prawo gdy porusza się po osi y
        else if (direction.y != 0f)   
        {
            if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
            {
                input = Vector2.left;
            }
            else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
            {
                input = Vector2.right;
            }
        }    
        
    }

    private void FixedUpdate()
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
        nextUpdate = Time.time + (1f / (speed * speedMultiplier));
    }

    private void Grow()
    {
        Transform segment = Instantiate(this.segmentPrefab);
        segment.position = segments[segments.Count - 1].position;

        segments.Add(segment);
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

        this.transform.position = Vector2.zero;                
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Food"){
            Grow();
        }
        else if (other.tag == "Obstacle"){
            ResetState();
        }        
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
