using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class playerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public static playerMovement Instance;

    [Header("Events")]
    UnityEvent shiftRun = new UnityEvent();
    UnityEvent sceneChange = new UnityEvent();
    UnityEvent inventoryActions = new UnityEvent();

    [Header("Components")]
    public float speed;
    public GameObject inventoryPanel;

    public List<GameObject> inventoryPages;
    private int inventoryIndex = 0;

    [Header("Settings")]
    public bool holdI = false;

    private Rigidbody2D player;


 void Awake()
    {
        // Prevent duplicates
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            if (inventoryPanel != null)
                DontDestroyOnLoad(inventoryPanel);
        }
        else
        {
            Destroy(gameObject); // Only keep the first instance
        }
    }
    void Start()
    {
        player = GetComponent<Rigidbody2D>();
        player.sleepMode = RigidbodySleepMode2D.NeverSleep; //onTriggerStay stopped because rigid body slept :skull:

        shiftRun.AddListener(move);// can chain events like this

        sceneChange.AddListener(clickDoor);

        inventoryActions.AddListener(changeInventoryPage);

        Debug.Log("Yippie");

        inventoryPanel.SetActive(false);
        foreach (GameObject page in inventoryPages)
        {
            page.SetActive(false);
        }
    }
    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector2 direction = new Vector2(horizontalInput, verticalInput);

        player.velocity = direction * speed;
        player.constraints = RigidbodyConstraints2D.FreezeRotation;

        shiftRun.Invoke();
        handleInventory();

    }
    void OnCollisionEnter2D(Collision2D col)
    {
        //Debug.Log("Collision");
    }
    void OnTriggerStay2D(Collider2D col)
    {
        Debug.Log("Triggered Door!");
        if (col.gameObject.CompareTag("door") && Input.GetKeyDown(KeyCode.Mouse1) && sceneChange != null)
        {
            sceneChange.Invoke();
        }
    }

    void handleInventory()
    {
        if (inventoryPanel.activeSelf)
        {
            inventoryActions.Invoke();
            speed = 0;
        }
        if (!holdI && Input.GetKeyDown(KeyCode.Tab))
        {
            if (inventoryPanel.activeSelf)
            {
                inventoryPanel.SetActive(false);
            }
            else
            {
                inventoryPanel.SetActive(true);
            }
        }
        else if (holdI && Input.GetKey(KeyCode.Tab)) //put the do function
        {
            inventoryPanel.SetActive(true);
        }
        else if (holdI)
        {
            inventoryPanel.SetActive(false);
        }
    }

    void changeInventoryPage()
    {

        int index = inventoryIndex * 2; //current Index

        if (Input.GetKeyDown(KeyCode.A)) //left page decrement
        {
            if (inventoryIndex > 0)
            {
                inventoryPages[index].SetActive(false);
                inventoryPages[index + 1].SetActive(false);
                inventoryIndex--;
            }
        }
        else if (Input.GetKeyDown(KeyCode.D)) //right page increment
        {
            if (inventoryIndex * 2 < inventoryPages.Count - 2) //we have -2 because invIndex should go from 0 to 2 (if no -2 it goes to 3 which is out of range)
            {
                inventoryPages[index].SetActive(false);
                inventoryPages[index + 1].SetActive(false);
                inventoryIndex++;
            }
        }

        index = inventoryIndex * 2;

        inventoryPages[index].SetActive(true);
        inventoryPages[index + 1].SetActive(true);
    }

    public void move()
    {
        if (Input.GetKey(KeyCode.LeftShift) && shiftRun != null)
        {
            speed = 6;
        }
        else
        {
            speed = 4;
        }

    }
    public void clickDoor()
    {
        SceneManager.LoadScene(2); //Wet Ruins
    }


    
}
