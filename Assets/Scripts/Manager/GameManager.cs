using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region Singleton
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
    #region Manager Management
    private PlayerManager playerManager;
    public PlayerManager PlayerManager => playerManager;
    //private ObstacleManager obstacleManager;
    //public ObstacleManager ObstacleManager => obstacleManager;
    private ItemManager itemManager;
    public ItemManager ItemManager => itemManager;
    private UIManager uiManager;
    public UIManager UIManager => uiManager;
    private JumpPad jumpPad;
    public JumpPad JumpPad => jumpPad;
    #endregion

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            if (_instance != this)
            {
                Destroy(gameObject);
                return;
            }
        }

        playerManager = FindObjectOfType<PlayerManager>();
        //obstacleManager = FindObjectOfType<ObstacleManager>();
        uiManager = FindObjectOfType<UIManager>();


    }
    private void Start()
    {
        playerManager.Init();
        //obstacleManager.Init();
        //uiManager.Init();
    }
}
