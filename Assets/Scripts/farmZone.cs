using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class farmZone : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("Crops")]
    [SerializeField] public GameObject carrot;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerStay2D(Collider2D col)
    {
        if(Input.GetKey(KeyCode.Mouse1) && col.gameObject.CompareTag("player"))
        {
            //plant crop xs
        }
        if (Input.GetKey(KeyCode.X))
        {
            //do something
        }
    }
}
