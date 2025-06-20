using UnityEngine;

public class gameManager : MonoBehaviour
{
    public static gameManager Instance;

    public GameObject playerPrefab;  // Assign your player prefab here in Inspector
    private GameObject playerInstance;
    public GameObject inventoryManagerPrefab;  // Assign your player prefab here in Inspector
    private GameObject inventoryManagerInstance;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);

            // Try to find existing player in scene
            playerInstance = GameObject.FindWithTag("player");
            
            inventoryManagerInstance = GameObject.FindWithTag("inventoryManager");

            if (playerInstance == null && playerPrefab != null)
            {
                // Instantiate player if not found
                playerInstance = Instantiate(playerPrefab);
            }
            // Make player persistent
            if (playerInstance != null)
            {
                DontDestroyOnLoad(playerInstance);
            }

            // Make player persistent
            if (inventoryManagerInstance != null)
            {
                DontDestroyOnLoad(inventoryManagerInstance);
            }

            if (inventoryManagerInstance == null && inventoryManagerPrefab != null)
            {
                // Instantiate player if not found
                inventoryManagerInstance = Instantiate(inventoryManagerPrefab);
            }

            
        }
        else
        {
            Destroy(gameObject); // Destroy duplicate GameManager
        }
    }
}
