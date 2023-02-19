using UnityEngine;

public class Food : MonoBehaviour
{
    public BoxCollider2D gridArea;
    private Snake snake;

    private void Start()
    {
        RandomizePosition();
    }
    private void Awake()
    {
        snake = FindObjectOfType<Snake>();
    }

    private void RandomizePosition()
    {
        Bounds bounds = this.gridArea.bounds;

        // Wybierz losową pozycję w ramach mapy
        float x = Random.Range(bounds.min.x, bounds.max.x);
        float y = Random.Range(bounds.min.y, bounds.max.y);

        x = Mathf.Round(x);
        y = Mathf.Round(y);

        // Uniemożliwienie spawnu jedzenia w wężu
        while (snake.Occupies(x, y))
        {
            x++;

            if (x > bounds.max.x)
            {
                x = bounds.min.x;
                y++;

                if (y > bounds.max.y)
                {
                    y = bounds.min.y;
                }
            }
        }

        transform.position = new Vector2(x, y);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player"){
            RandomizePosition();
        }        
    }
}
