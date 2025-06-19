using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class demo : MonoBehaviour
{
    public inventoryManager inventorySlot;
    public item[] itemsToPick;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void pick(int id)
    {
        inventorySlot.AddItem(itemsToPick[id]);
    }
}
