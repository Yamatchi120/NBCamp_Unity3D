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
    //[SerializeField] private PlayerManager playerManager;
    //public PlayerManager PlayerManager => playerManager;
    //private ObstacleManager obstacleManager;
    //public ObstacleManager ObstacleManager => obstacleManager;
    [SerializeField] private PlayerController _playerController;
    public PlayerController PlayerController => _playerController;
    private ItemManager _itemManager;
    public ItemManager ItemManager => _itemManager;
    private UIManager _uiManager;
    public UIManager UIManager => _uiManager;
    private JumpPad _jumpPad;
    public JumpPad JumpPad => _jumpPad;
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

        //obstacleManager = FindObjectOfType<ObstacleManager>();
        _playerController = FindObjectOfType<PlayerController>();
        _uiManager = FindObjectOfType<UIManager>();

    }
    private void Start()
    {
        //obstacleManager.Init();
        _uiManager.Init();
    }
}
