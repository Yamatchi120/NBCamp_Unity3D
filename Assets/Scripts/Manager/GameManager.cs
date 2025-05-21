using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region ΩÃ±€≈Ê
    private static GameManager _instance;
    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                GameObject go = new GameObject("GameManager");
                _instance = go.AddComponent<GameManager>();
                DontDestroyOnLoad(go);
            }
            return _instance;
        }
    }
    #endregion
<<<<<<< Updated upstream
    private PlayerController playerController;
    public PlayerController PlayerController => playerController;
=======
    #region Manager Management
    private PlayerManager playerManager;
    public PlayerManager PlayerManager => playerManager;
    private ItemManager itemManager;
    public ItemManager ItemManager => itemManager;
    private ObstacleManager obstacleManager;
    public ObstacleManager ObstacleManager => obstacleManager;
>>>>>>> Stashed changes
    private JumpPad jumpPad;
    public JumpPad JumpPad => jumpPad;


    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
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
    private void Start()
    {

    }
}
