using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class playerMovement : MonoBehaviour
{
    // Start is called before the first frame update

    [Header("Events")]
    UnityEvent shiftRun = new UnityEvent();
    UnityEvent sceneChange = new UnityEvent();

    [Header("Components")]
    public float speed;
    public GameObject inventoryPanel;

    [Header("Settings")]
    public bool holdI = false;

    private Rigidbody2D player;

    void Start()
    {
        player = GetComponent<Rigidbody2D>();
        player.sleepMode = RigidbodySleepMode2D.NeverSleep; //onTriggerStay stopped because rigid body slept :skull:

        shiftRun.AddListener(shiftRunFunc);
        sceneChange.AddListener(clickDoor);
        

        Debug.Log("Yippie");

        inventoryPanel.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector2 direction = new Vector2(horizontalInput, verticalInput);

        player.velocity = direction * speed;
        player.constraints = RigidbodyConstraints2D.FreezeRotation;

        if (Input.GetKey(KeyCode.LeftShift) && shiftRun != null)
        {
            shiftRun.Invoke();
        }
        else
        {
            speed = 4;
        }

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
        else if(holdI)
        {
            inventoryPanel.SetActive(false);
        }
    }
    public void shiftRunFunc()
    {
        speed = 6;
    }
    public void clickDoor()
    {
        SceneManager.LoadScene(2); //Wet Ruins
    }
    
}
