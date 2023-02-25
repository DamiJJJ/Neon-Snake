using UnityEngine;

public class Click : MonoBehaviour
{
    public static Click instance;
    void Awake()
    {
        if (instance != null && instance != this)
            Destroy(gameObject);
        else
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }
}
