using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    
    [Header("Database")]
    public DatabaseManager databaseManager;
    
    [Header("System")]
    public bool isDatabaseInitialized = false;
    
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            InitializeSystems();
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
    private void InitializeSystems()
    {
        Debug.Log("🔄 Инициализация систем магазина...");
        
        // Первым делом - база данных
        databaseManager = FindObjectOfType<DatabaseManager>();
        if (databaseManager == null)
        {
            GameObject dbObj = new GameObject("DatabaseManager");
            databaseManager = dbObj.AddComponent<DatabaseManager>();
            DontDestroyOnLoad(dbObj);
        }
        
        Debug.Log("✅ Менеджеры инициализированы!");
    }
    
    void Update()
    {
        // Для тестирования - выводим статус по нажатию пробела
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log($"📊 Статус БД: {databaseManager?.IsInitialized ?? false}");
        }
    }
}