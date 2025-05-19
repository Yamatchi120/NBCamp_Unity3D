using UnityEngine;

public class GameManager : MonoBehaviour
{
    private  static GameManager _instance;

    public PlayerController playerController;

    private void Awake()
    {
        Init();
    }

    void Init()
    {
        if (_instance == null)
        {
            _instance = new GameObject("GameManager").AddComponent<GameManager>();
            DontDestroyOnLoad(gameObject);

            playerController = FindObjectOfType<PlayerController>();
        }
        else
        {
            if (_instance != this)
            {
                Destroy(gameObject);
                return;
            }
        }
    }
}
