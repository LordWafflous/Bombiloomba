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

    private Rigidbody2D player;
    

    void Start()
    {
        player = GetComponent<Rigidbody2D>();
        player.sleepMode = RigidbodySleepMode2D.NeverSleep; //onTriggerStay stopped because rigid body slept :skull:

        shiftRun.AddListener(shiftRunFunc);
        sceneChange.AddListener(clickDoor);

        Debug.Log("Yippie");
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector2 direction = new Vector2(horizontalInput, verticalInput);

        player.velocity = direction*speed;
        player.constraints = RigidbodyConstraints2D.FreezeRotation;

        if(Input.GetKey(KeyCode.LeftShift) && shiftRun != null)
        {
            shiftRun.Invoke();
        }
        else
        {
            speed = 4;
        }
    }

     void OnCollisionEnter2D(Collision2D col)
     {
        //Debug.Log("Collision");
        
     }


     void OnTriggerStay2D(Collider2D col)
     {
        if(col.gameObject.CompareTag("door") && (Input.GetKey(KeyCode.Mouse1)))
        {
            sceneChange.Invoke();
        }
     }

     public void shiftRunFunc()
     {
        speed = 6;
     }
    
    public void clickDoor()
    {
        SceneManager.LoadScene("wetRuins");
    }
}
