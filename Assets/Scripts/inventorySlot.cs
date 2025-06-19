using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class inventorySlot : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IDropHandler, IPointerClickHandler
{
    public static List<inventorySlot> allSlots = new List<inventorySlot>();
    [Header("UI")]
    public Image slot;
    public Image frame;
    public enum SlotType { Inventory, Hotbar}
    public SlotType slotType;

    private Color ogColorSlot;
    private Color ogColorFrame;
    private bool clickSlot = false;

    // Start is called before the first frame update
    void Start()
    {
        ogColorSlot = slot.color;
        ogColorFrame = frame.color;

        if (slotType != SlotType.Hotbar)
        {
            slotType = SlotType.Inventory;
        }

        allSlots.Add(this);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        slot.color = (clickSlot) ? new Color(0.6f, 1f, 0.6f, 1f) : new Color(0.6f, 0.6f, 0.6f, 1f); //first one is iverted weird colors
        frame.color = (clickSlot) ? new Color(1f, 1f, 0.6f, 1f) : new Color(0.6f, 0.6f, 0.6f, 1f); //first one is iverted weird colors
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        slot.color = (clickSlot) ? new Color(0.6f, 1f, 1f, 1f) : ogColorSlot; //first one is iverted weird colors
        frame.color = (clickSlot) ? new Color(1f, 1f, 1f, 1f) : ogColorFrame; //first one is iverted weird colors
    }

    public void OnDrop(PointerEventData eventData)
    {
        if (transform.childCount == 0)
        {
            inventoryItem inventoryItem = eventData.pointerDrag.GetComponent<inventoryItem>();
            inventoryItem.parentAfterDrag = transform;
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        //do this for hotbar and inventory slots with iffs twice basically



        foreach (inventorySlot item in allSlots)
        {
            if (item.slotType != this.slotType)
            {
                continue;
            }

            item.slot.color = ogColorSlot;
            item.frame.color = ogColorFrame;
            item.clickSlot = false;
        }
        clickSlot = clickSlot ? false : true;
        frame.color = new Color(1f, 1f, 1f, 1f);
        slot.color = new Color(0.6f, 1f, 1f, 1f);
    }
}
