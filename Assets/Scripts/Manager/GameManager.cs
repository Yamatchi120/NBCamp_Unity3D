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
    private JumpPad jumpPad;
    public JumpPad JumpPad => jumpPad;
    #endregion

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);

            playerManager = FindObjectOfType<PlayerManager>();
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
