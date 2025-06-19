using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inventoryManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject inventoryItemPrefab;
    public List<inventorySlot> allSlots;

    public bool AddItem(item leItem)
    {
        for (int i = 0; i < allSlots.Count; i++)
        {
            inventorySlot emptySlot = allSlots[i];
            inventoryItem avaibleSlotItem = emptySlot.GetComponentInChildren<inventoryItem>();
            if ( avaibleSlotItem == null)
            {
                SpawnNewItem(leItem, emptySlot);
                return true;
            }
            else if (avaibleSlotItem.item.itemType == leItem.itemType && avaibleSlotItem.count < 64)
            {
                avaibleSlotItem.count++;
                avaibleSlotItem.refreshCount();
                return true;
            }
        }
        return false; 
    }

    void SpawnNewItem(item leItem, inventorySlot emptySlot) //into first u should look into inventory then hotbar
    {
        GameObject newItemGo = Instantiate(inventoryItemPrefab, emptySlot.transform); //straight uo create =s a new gameobject on the scene
        inventoryItem iItem = newItemGo.GetComponent<inventoryItem>();
        iItem.InitializeItem(leItem);
    }
}
